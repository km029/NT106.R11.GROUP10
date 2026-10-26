using System;
using System.Net.Http;
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
            Timeout = TimeSpan.FromSeconds(20)
        };

        internal static string AccessToken { get; private set; }
        internal static string RefreshToken { get; private set; }

        internal static async Task SignUpAsync(
            string username, string email, string password)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/auth/v1/signup";

            string json = JsonConvert.SerializeObject(new
            {
                email = email,
                password = password,
                data = new { username = username }
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add(
                    "apikey", SupabaseConfig.PublishableKey);

                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            "Supabase trả về HTTP "
                            + (int)response.StatusCode
                            + ". Chưa tạo được tài khoản.");
                    }
                }
            }
        }

        internal static async Task SignInAsync(string email, string password)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/auth/v1/token?grant_type=password";

            string json = JsonConvert.SerializeObject(new
            {
                email = email,
                password = password
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add(
                    "apikey", SupabaseConfig.PublishableKey);

                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(
                            "Đăng nhập không thành công (HTTP "
                            + (int)response.StatusCode
                            + "). Kiểm tra email, mật khẩu và trạng thái xác nhận email.");
                    }

                    string body = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(body);

                    string accessToken = (string)result["access_token"];
                    string refreshToken = (string)result["refresh_token"];

                    if (string.IsNullOrEmpty(accessToken))
                    {
                        throw new InvalidOperationException(
                            "Supabase không trả về phiên đăng nhập.");
                    }

                    AccessToken = accessToken;
                    RefreshToken = refreshToken;
                }
            }
        }

        internal static async Task SendPasswordResetAsync(string email)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/auth/v1/recover";

            string json = JsonConvert.SerializeObject(new { email = email });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(
                            "Không gửi được yêu cầu khôi phục (HTTP "
                            + (int)response.StatusCode + ").");
                    }
                }
            }
        }

        internal static async Task ResetPasswordAsync(
    string email, string code, string newPassword)
        {
            string baseUrl = SupabaseConfig.ProjectUrl.TrimEnd('/');

            // Bước 1: Xác minh mã của email đang khôi phục.
            string verifyJson = JsonConvert.SerializeObject(new
            {
                email = email,
                token = code,
                type = "recovery"
            });

            string recoveryAccessToken;

            using (var request = new HttpRequestMessage(
                HttpMethod.Post, baseUrl + "/auth/v1/verify"))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    verifyJson, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(
                            "Mã khôi phục không hợp lệ hoặc đã hết hạn (HTTP "
                            + (int)response.StatusCode + ").");
                    }

                    string body = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(body);
                    recoveryAccessToken = (string)result["access_token"];

                    if (string.IsNullOrWhiteSpace(recoveryAccessToken))
                    {
                        throw new InvalidOperationException(
                            "Đã xác minh mã nhưng không nhận được phiên khôi phục.");
                    }
                }
            }

            // Bước 2: Dùng CHÍNH phiên khôi phục vừa nhận để đổi mật khẩu.
            string updateJson = JsonConvert.SerializeObject(new
            {
                password = newPassword
            });

            using (var request = new HttpRequestMessage(
                HttpMethod.Put, baseUrl + "/auth/v1/user"))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer", recoveryAccessToken);

                request.Content = new StringContent(
                    updateJson, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(
                            "Mã đã được xác minh nhưng chưa đổi được mật khẩu (HTTP "
                            + (int)response.StatusCode
                            + "). Có thể bạn cần yêu cầu mã mới để thử lại.");
                    }
                }
            }
        }
    }
}