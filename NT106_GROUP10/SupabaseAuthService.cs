using System;
using System.Linq;
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
        internal static string CurrentUserId { get; private set; }

        // Hàm dùng chung kiểm tra mật khẩu: >= 8 ký tự, hoa, thường, số, ký tự đặc biệt
        internal static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            bool hasMinLength = password.Length >= 8;
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));

            return hasMinLength && hasUpper && hasLower && hasDigit && hasSpecial;
        }

        internal static async Task<bool> AccountExistsAsync(string usernameOrEmail)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/rest/v1/rpc/check_account_exists";

            string json = JsonConvert.SerializeObject(new
            {
                p_input = usernameOrEmail.Trim()
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        return false;

                    string body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(body);
                }
            }
        }

        internal static async Task<string> CheckDuplicateAsync(string username, string email)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/rest/v1/rpc/check_registration_duplicate";

            string json = JsonConvert.SerializeObject(new
            {
                p_username = username,
                p_email = email
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        return "OK";

                    string body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(body);
                }
            }
        }

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
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorBody = await response.Content.ReadAsStringAsync();
                        throw new Exception(
                            "Supabase trả về HTTP " + (int)response.StatusCode + ": " + errorBody);
                    }
                }
            }
        }

        private static async Task<string> GetEmailByUsernameAsync(string username)
        {
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/rest/v1/rpc/get_email_by_username";

            string json = JsonConvert.SerializeObject(new
            {
                p_username = username
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Headers.Add("Authorization", "Bearer " + SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                        return null;

                    string body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(body);
                }
            }
        }

        internal static async Task SignInAsync(string usernameOrEmail, string password)
        {
            string input = usernameOrEmail.Trim();

            // 1. Kiểm tra tài khoản (username hoặc email) đã tồn tại chưa
            bool exists = await AccountExistsAsync(input);
            if (!exists)
            {
                throw new InvalidOperationException("ACCOUNT_NOT_FOUND");
            }

            // 2. Nếu là username thì quy đổi sang email
            string emailToLogin = input;
            if (!emailToLogin.Contains("@"))
            {
                emailToLogin = await GetEmailByUsernameAsync(emailToLogin);
                if (string.IsNullOrWhiteSpace(emailToLogin))
                {
                    throw new InvalidOperationException("ACCOUNT_NOT_FOUND");
                }
            }

            // 3. Tiến hành đăng nhập
            string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                         + "/auth/v1/token?grant_type=password";

            string json = JsonConvert.SerializeObject(new
            {
                email = emailToLogin,
                password = password
            });

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                request.Content = new StringContent(
                    json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await Http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException("WRONG_CREDENTIALS");
                    }

                    string body = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(body);

                    string accessToken = (string)result["access_token"];
                    string refreshToken = (string)result["refresh_token"];

                    if (string.IsNullOrEmpty(accessToken))
                    {
                        throw new InvalidOperationException("WRONG_CREDENTIALS");
                    }

                    AccessToken = accessToken;
                    RefreshToken = refreshToken;
                    CurrentUserId = (string)result["user"]?["id"];

                    await UpdateUserPresenceAsync("online");
                }
            }
        }

        internal static async Task UpdateUserPresenceAsync(string status)
        {
            if (string.IsNullOrEmpty(AccessToken) || string.IsNullOrEmpty(CurrentUserId))
                return;

            try
            {
                string url = SupabaseConfig.ProjectUrl.TrimEnd('/')
                             + "/rest/v1/profiles?id=eq." + CurrentUserId;

                string json = JsonConvert.SerializeObject(new
                {
                    status = status,
                    last_seen_at = DateTime.UtcNow.ToString("o")
                });

                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url))
                {
                    request.Headers.Add("apikey", SupabaseConfig.PublishableKey);
                    request.Headers.Add("Authorization", "Bearer " + AccessToken);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    await Http.SendAsync(request);
                }
            }
            catch { }
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