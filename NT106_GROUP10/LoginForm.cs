using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // Bật DoubleBuffered cho pnlLogin và toàn bộ nút bấm, ô nhập bên trong
            EnableDoubleBuffer(pnlLogin);
            foreach (Control ctrl in pnlLogin.Controls)
            {
                EnableDoubleBuffer(ctrl);
            }

            // Dùng màu đặc thay cho FromArgb(220,...) để hover nút không ép vẽ lại ảnh nền
            pnlLogin.BackColor = Color.White;
        }

        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.TextButton.Trim();
            string password = txtPassword.TextButton;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản (username hoặc email) và mật khẩu!");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.ButtonText = "Đang đăng nhập...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await SupabaseAuthService.SignInAsync(email, password);
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                if (ex.Message == "ACCOUNT_NOT_FOUND")
                {
                    MessageBox.Show(
                        "Tài khoản chưa tồn tại, vui lòng đăng ký.",
                        "Chưa có tài khoản",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Sai mật khẩu hoặc tài khoản.",
                        "Đăng nhập chưa thành công",
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            using (var form = new ForgotPasswordForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}