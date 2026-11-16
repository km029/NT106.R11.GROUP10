
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NT106_GROUP10
{
    internal static class SupabaseAuthService
    {
        private static readonly HttpClient Http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        internal static string AccessToken { get; private set; }
        internal static string RefreshToken { get; private set; }
        internal static string CurrentUserId { get; private set; }

        // Email thật lấy trực tiếp từ Supabase Auth.
        internal static string CurrentUserEmail { get; private set; }

        private static string BaseUrl
        {
            get { return SupabaseConfig.ProjectUrl.TrimEnd('/'); }
        }

        private static HttpRequestMessage CreateRequest(
            HttpMethod method, string url, bool useUserToken = false)
        {
            HttpRequestMessage request =
                new HttpRequestMessage(method, url);

            request.Headers.Add("apikey", SupabaseConfig.PublishableKey);

            string token = useUserToken && !string.IsNullOrWhiteSpace(AccessToken)
                ? AccessToken
                : SupabaseConfig.PublishableKey;

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return request;
        }

        internal static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            return password.Length >= 8
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsDigit)
                && password.Any(ch =>
                    !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));
        }

        internal static async Task<bool> AccountExistsAsync(
            string usernameOrEmail)
        {
            string url = BaseUrl + "/rest/v1/rpc/check_account_exists";

            string json = JsonConvert.SerializeObject(new
            {
                p_input = usernameOrEmail.Trim()
            });

            using (var request = CreateRequest(HttpMethod.Post, url))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Không kiểm tra được tài khoản: " + body);

                    return JsonConvert.DeserializeObject<bool>(body);
                }
            }
        }

        internal static async Task<string> CheckDuplicateAsync(
            string username, string email)
        {
            string url = BaseUrl
                + "/rest/v1/rpc/check_registration_duplicate";

            string json = JsonConvert.SerializeObject(new
            {
                p_username = username,
                p_email = email
            });

            using (var request = CreateRequest(HttpMethod.Post, url))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Không kiểm tra được dữ liệu đăng ký: " + body);

                    return JsonConvert.DeserializeObject<string>(body);
                }
            }
        }

        internal static async Task SignUpAsync(
            string username, string email, string password)
        {
            string url = BaseUrl + "/auth/v1/signup";

            string json = JsonConvert.SerializeObject(new
            {
                email = email,
                password = password,
                data = new { username = username }
            });

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Supabase trả về HTTP "
                            + (int)response.StatusCode + ": " + body);
                }
            }
        }

        private static async Task<string> GetEmailByUsernameAsync(
            string username)
        {
            string url = BaseUrl + "/rest/v1/rpc/get_email_by_username";

            string json = JsonConvert.SerializeObject(new
            {
                p_username = username
            });

            using (var request = CreateRequest(HttpMethod.Post, url))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        return null;

                    string body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(body);
                }
            }
        }

        internal static async Task SignInAsync(
            string usernameOrEmail, string password)
        {
            string input = usernameOrEmail.Trim();

            bool exists = await AccountExistsAsync(input);

            if (!exists)
                throw new InvalidOperationException("ACCOUNT_NOT_FOUND");

            string emailToLogin = input;

            if (!emailToLogin.Contains("@"))
            {
                emailToLogin = await GetEmailByUsernameAsync(emailToLogin);

                if (string.IsNullOrWhiteSpace(emailToLogin))
                    throw new InvalidOperationException("ACCOUNT_NOT_FOUND");
            }

            string url = BaseUrl + "/auth/v1/token?grant_type=password";

            string json = JsonConvert.SerializeObject(new
            {
                email = emailToLogin,
                password = password
            });

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException(
                            "WRONG_CREDENTIALS");

                    JObject result = JObject.Parse(body);

                    AccessToken = (string)result["access_token"];
                    RefreshToken = (string)result["refresh_token"];
                    CurrentUserId = (string)result["user"]?["id"];

                    // Email lấy từ Auth, không lấy từ profiles.
                    CurrentUserEmail = (string)result["user"]?["email"];

                    if (string.IsNullOrWhiteSpace(AccessToken) ||
                        string.IsNullOrWhiteSpace(CurrentUserId) ||
                        string.IsNullOrWhiteSpace(CurrentUserEmail))
                    {
                        throw new Exception(
                            "Supabase không trả về đủ thông tin tài khoản.");
                    }

                    await UpdateUserPresenceAsync("online");
                }
            }
        }

        internal static async Task<JObject> GetCurrentProfileAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentUserId) ||
                string.IsNullOrWhiteSpace(AccessToken))
            {
                throw new InvalidOperationException("Bạn chưa đăng nhập.");
            }

            string url = BaseUrl
                + "/rest/v1/profiles?id=eq."
                + Uri.EscapeDataString(CurrentUserId)
                + "&select=id,username,email,display_name,avatar_url,bio,status";

            using (var request = CreateRequest(HttpMethod.Get, url, true))
            using (HttpResponseMessage response =
                await Http.SendAsync(request))
            {
                string body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Không lấy được hồ sơ: " + body);

                JArray rows = JArray.Parse(body);

                if (rows.Count == 0)
                    throw new Exception(
                        "Không tìm thấy hồ sơ trong bảng profiles.");

                return (JObject)rows[0];
            }
        }

        internal static async Task UpdateDisplayNameAsync(string displayName)
        {
            string url = BaseUrl
                + "/rest/v1/profiles?id=eq."
                + Uri.EscapeDataString(CurrentUserId);

            string json = JsonConvert.SerializeObject(new
            {
                display_name = displayName
            });

            using (var request = CreateRequest(
                new HttpMethod("PATCH"), url, true))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Không cập nhật được tên hiển thị: " + body);
                }
            }
        }

        internal static async Task<string> UploadAvatarAsync(
            byte[] imageBytes, string extension, string contentType)
        {
            if (string.IsNullOrWhiteSpace(CurrentUserId) ||
                string.IsNullOrWhiteSpace(AccessToken))
            {
                throw new InvalidOperationException("Bạn chưa đăng nhập.");
            }

            string safeExtension = (extension ?? ".jpg").ToLowerInvariant();

            if (safeExtension != ".jpg" &&
                safeExtension != ".jpeg" &&
                safeExtension != ".png" &&
                safeExtension != ".bmp")
            {
                safeExtension = ".jpg";
            }

            // Tên file mới để không cần quyền ghi đè file cũ.
            string fileName = Guid.NewGuid().ToString("N") + safeExtension;
            string objectPath = CurrentUserId + "/" + fileName;

            string url = BaseUrl
                + "/storage/v1/object/avatars/"
                + Uri.EscapeDataString(CurrentUserId)
                + "/" + Uri.EscapeDataString(fileName);

            using (var request = CreateRequest(HttpMethod.Post, url, true))
            {
                request.Headers.Add("x-upsert", "false");
                request.Content = new ByteArrayContent(imageBytes);
                request.Content.Headers.ContentType =
                    new MediaTypeHeaderValue(contentType);

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Không tải được ảnh lên Supabase Storage: " + body);
                }
            }

            string publicUrl = BaseUrl
                + "/storage/v1/object/public/avatars/"
                + Uri.EscapeDataString(CurrentUserId)
                + "/" + Uri.EscapeDataString(fileName);

            await UpdateAvatarUrlAsync(publicUrl);

            return publicUrl;
        }

        private static async Task UpdateAvatarUrlAsync(string avatarUrl)
        {
            string url = BaseUrl
                + "/rest/v1/profiles?id=eq."
                + Uri.EscapeDataString(CurrentUserId);

            string json = JsonConvert.SerializeObject(new
            {
                avatar_url = avatarUrl
            });

            using (var request = CreateRequest(
                new HttpMethod("PATCH"), url, true))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(
                            "Đã tải ảnh lên nhưng không lưu được đường dẫn ảnh: "
                            + body);
                }
            }
        }

        internal static async Task UpdateUserPresenceAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(AccessToken) ||
                string.IsNullOrWhiteSpace(CurrentUserId))
                return;

            string url = BaseUrl
                + "/rest/v1/profiles?id=eq."
                + Uri.EscapeDataString(CurrentUserId);

            string json = JsonConvert.SerializeObject(new
            {
                status = status,
                last_seen_at = DateTime.UtcNow.ToString("o")
            });

            using (var request = CreateRequest(
                new HttpMethod("PATCH"), url, true))
            {
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        throw new Exception(
                            "Không cập nhật được trạng thái: " + body);
                    }
                }
            }
        }

        internal static async Task SendPasswordResetAsync(string email)
        {
            string url = BaseUrl + "/auth/v1/recover";

            string json = JsonConvert.SerializeObject(new
            {
                email = email
            });

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException(
                            "Không gửi được yêu cầu khôi phục (HTTP "
                            + (int)response.StatusCode + ").");
                }
            }
        }

        internal static async Task ResetPasswordAsync(
            string email, string code, string newPassword)
        {
            string verifyJson = JsonConvert.SerializeObject(new
            {
                email = email,
                token = code,
                type = "recovery"
            });

            string recoveryAccessToken;

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, BaseUrl + "/auth/v1/verify"))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    verifyJson, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException(
                            "Mã khôi phục không hợp lệ hoặc đã hết hạn (HTTP "
                            + (int)response.StatusCode + ").");

                    string body = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(body);
                    recoveryAccessToken = (string)result["access_token"];

                    if (string.IsNullOrWhiteSpace(recoveryAccessToken))
                        throw new InvalidOperationException(
                            "Không nhận được phiên khôi phục.");
                }
            }

            string updateJson = JsonConvert.SerializeObject(new
            {
                password = newPassword
            });

            using (var request = new HttpRequestMessage(
                HttpMethod.Put, BaseUrl + "/auth/v1/user"))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer", recoveryAccessToken);

                request.Content = new StringContent(
                    updateJson, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException(
                            "Chưa đổi được mật khẩu (HTTP "
                            + (int)response.StatusCode + ").");
                }
            }
        }

        internal static async Task SignOutAsync()
        {
            if (!string.IsNullOrWhiteSpace(AccessToken))
            {
                try
                {
                    using (var request = CreateRequest(
                        HttpMethod.Post, BaseUrl + "/auth/v1/logout", true))
                    {
                        await Http.SendAsync(request);
                    }
                }
                catch { }
            }

            AccessToken = null;
            RefreshToken = null;
            CurrentUserId = null;
            CurrentUserEmail = null;
        }
    }
}
