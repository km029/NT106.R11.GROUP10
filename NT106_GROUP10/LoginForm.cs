
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace NT106_GROUP10
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            this.UpdateStyles();

            EnableDoubleBuffer(pnlLogin);

            foreach (Control ctrl in pnlLogin.Controls)
            {
                EnableDoubleBuffer(ctrl);
            }

            pnlLogin.BackColor = Color.White;
        }

        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                control,
                new object[] { true });
        }

        // =========================================
        // ĐĂNG NHẬP
        // =========================================

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.TextButton.Trim();
            string password = txtPassword.TextButton;

            if (string.IsNullOrWhiteSpace(usernameOrEmail) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            btnLogin.Enabled = false;
            btnLogin.ButtonText = "Đang đăng nhập...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // BƯỚC 1: Đăng nhập và xác thực bằng Supabase.
                await SupabaseAuthService.SignInAsync(
                    usernameOrEmail,
                    password);

                // BƯỚC 2: Lấy UID thật từ Supabase Auth.
                string supabaseUserId =
                    SupabaseAuthService.CurrentUserId;

                if (string.IsNullOrWhiteSpace(supabaseUserId))
                {
                    throw new Exception(
                        "Không lấy được UID từ Supabase.");
                }

                // BƯỚC 3: Lấy thông tin hồ sơ từ bảng profiles.
                JObject profile =
                    await SupabaseAuthService.GetCurrentProfileAsync();

                string profileId =
                    (string)profile["id"];

                string email = SupabaseAuthService.CurrentUserEmail;

                string username =
                    (string)profile["username"];

                string displayName =
                    (string)profile["display_name"];

                // Kiểm tra UID trong profiles có khớp Auth không.
                if (string.IsNullOrWhiteSpace(profileId) ||
                    !string.Equals(
                        profileId,
                        supabaseUserId,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(
                        "UID trong bảng profiles không khớp với tài khoản Supabase Auth.");
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception(
                        "Không tìm thấy email trong bảng profiles. "
                        + "Vui lòng kiểm tra dữ liệu hồ sơ Supabase.");
                }

                // Nếu username chưa có thì lấy phần trước @ của email.
                if (string.IsNullOrWhiteSpace(username))
                {
                    username = email.Split('@')[0];
                }

                // Nếu chưa có tên hiển thị thì dùng username.
                if (string.IsNullOrWhiteSpace(displayName))
                {
                    displayName = username;
                }

                // BƯỚC 4: Lưu thông tin tài khoản vào UserSession.
                UserSession.UserId = profileId;
                UserSession.Email = email;
                UserSession.DisplayName = displayName;

                // BƯỚC 5: Mở giao diện chính.
                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                // Xóa thông tin phiên người dùng nếu đăng nhập thất bại.
                UserSession.UserId = null;
                UserSession.Email = null;
                UserSession.DisplayName = null;

                if (ex.Message == "ACCOUNT_NOT_FOUND")
                {
                    MessageBox.Show(
                        "Tài khoản chưa tồn tại, vui lòng đăng ký.",
                        "Chưa có tài khoản",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (ex.Message == "WRONG_CREDENTIALS")
                {
                    MessageBox.Show(
                        "Sai mật khẩu hoặc tài khoản.",
                        "Đăng nhập chưa thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Không thể đăng nhập.\n\n" + ex.Message,
                        "Lỗi đăng nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                txtPassword.TextButton = "";
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.ButtonText = "Đăng nhập";
                this.Cursor = Cursors.Default;
            }
        }

        // =========================================
        // MỞ FORM ĐĂNG KÝ
        // =========================================

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
        }

        // =========================================
        // QUÊN MẬT KHẨU
        // =========================================

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            using (var form = new ForgotPasswordForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}
