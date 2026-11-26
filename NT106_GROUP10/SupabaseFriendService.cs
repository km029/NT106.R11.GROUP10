using System;
using System.Collections.Generic; 
using System.Net.Http;            
using System.Text;                
using System.Threading.Tasks;     
using Newtonsoft.Json;

namespace NT106_GROUP10
{
    // Khuôn mẫu (Model) hứng dữ liệu từng người dùng từ Supabase trả về
    internal class UserSearchResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("friendship_id")]
        public string FriendshipId { get; set; }

        [JsonProperty("friend_status")]
        public string FriendStatus { get; set; } // Trạng thái quan hệ 2 user có kết bạn chưa, hay đang gửi
    }

    internal static class SupabaseFriendService
    {
            // Khởi tạo bộ gửi/nhận HTTP 
        private static readonly HttpClient Http = new HttpClient
        {
                Timeout = TimeSpan.FromSeconds(15)
        };

        // gửi từ khóa lên Supabase và trả về danh sách Kqua
        internal static async Task<List<UserSearchResult>> SearchUsersAsync(string keyword)
        {
                // Kiểm tra an toàn: nếu từ khóa trống hoặc chưa đăng nhập thì trả về danh sách rỗng ngay
                if (string.IsNullOrWhiteSpace(keyword) || string.IsNullOrEmpty(SupabaseAuthService.AccessToken))
                    return new List<UserSearchResult>();

                string url = SupabaseConfig.ProjectUrl.TrimEnd('/') + "/rest/v1/rpc/search_users";

                string json = JsonConvert.SerializeObject(new
                {
                    p_keyword = keyword.Trim()
                });

                // Khởi tạo gói tin yêu cầu HTTP POST
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    // Gắn Token định danh của người dùng đang đăng nhập vào header
                    request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                    request.Headers.Add("Authorization", "Bearer " + SupabaseAuthService.AccessToken);

                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gửi gói tin đi và chờ phản hồi từ server 
                    using (HttpResponseMessage response = await Http.SendAsync(request))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            string err = await response.Content.ReadAsStringAsync();
                            throw new Exception("Lỗi tìm kiếm (HTTP " + (int)response.StatusCode + "): " + err);
                        }

                        string body = await response.Content.ReadAsStringAsync();

                        var results = JsonConvert.DeserializeObject<List<UserSearchResult>>(body);

                        // Nếu results bị null thì trả về danh sách rỗng 
                        return results ?? new List<UserSearchResult>();
                    }
                }
        }
        // Tự động trích xuất User ID (claim "sub") từ AccessToken đang đăng nhập
        private static string GetCurrentUserIdFromToken()
        {
            string token = SupabaseAuthService.AccessToken;
            if (string.IsNullOrEmpty(token))
                throw new Exception("Bạn chưa đăng nhập.");

            string[] parts = token.Split('.');
            if (parts.Length < 2)
                throw new Exception("Token đăng nhập không hợp lệ.");

            string payload = parts[1].Replace('-', '+').Replace('_', '/');
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }

            string json = Encoding.UTF8.GetString(Convert.FromBase64String(payload));
            var claims = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            if (claims != null && claims.ContainsKey("sub") && claims["sub"] != null)
                return claims["sub"].ToString();

            throw new Exception("Không xác định được ID người dùng hiện tại.");
        }

        // Gửi lời mời kết bạn (INSERT vào bảng friendships)
        internal static async Task<string> SendFriendRequestAsync(string targetUserId)
        {
            string currentUserId = GetCurrentUserIdFromToken();
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/') + "/rest/v1/friendships";

            string json = JsonConvert.SerializeObject(new
            {
                requester_id = currentUserId,
                addressee_id = targetUserId,
                status = "pending"
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseAuthService.AccessToken);
                request.Headers.Add("Prefer", "return=representation");
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Lỗi gửi lời mời (HTTP " + (int)response.StatusCode + "): " + body);

                    var createdRows = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(body);
                    if (createdRows != null && createdRows.Count > 0 && createdRows[0].ContainsKey("id"))
                        return createdRows[0]["id"]?.ToString();

                    return null;
                }
            }
        }

        // Chấp nhận lời mời kết bạn (UPDATE status = 'accepted')
        internal static async Task AcceptFriendRequestAsync(string friendshipId, string senderUserId)
        {
            string currentUserId = GetCurrentUserIdFromToken();

            string filter = !string.IsNullOrEmpty(friendshipId)
     ? "id=eq." + friendshipId
     : "requester_id=eq." + senderUserId + "&addressee_id=eq." + currentUserId + "&status=eq.pending";

            string url = SupabaseConfig.ProjectUrl.TrimEnd('/') + "/rest/v1/friendships?" + filter;
            string json = JsonConvert.SerializeObject(new { status = "accepted" });

            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseAuthService.AccessToken);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        throw new Exception("Lỗi chấp nhận kết bạn (HTTP " + (int)response.StatusCode + "): " + body);
                    }
                }
            }
        }

        // Hủy lời mời kết bạn đã gửi (DELETE dòng pending trong friendships)
        internal static async Task CancelFriendRequestAsync(string friendshipId, string targetUserId)
        {
            string currentUserId = GetCurrentUserIdFromToken();

            string filter = !string.IsNullOrEmpty(friendshipId)
    ? "id=eq." + friendshipId
    : "requester_id=eq." + currentUserId + "&addressee_id=eq." + targetUserId + "&status=eq.pending";

            string url = SupabaseConfig.ProjectUrl.TrimEnd('/') + "/rest/v1/friendships?" + filter;

            using (var request = new HttpRequestMessage(HttpMethod.Delete, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseAuthService.AccessToken);

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        throw new Exception("Lỗi hủy lời mời (HTTP " + (int)response.StatusCode + "): " + body);
                    }
                }
            }
        }
    }

}

