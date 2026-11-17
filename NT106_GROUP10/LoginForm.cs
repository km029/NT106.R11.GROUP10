using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class LoginForm : Form
    {
        private bool dangHienMatKhau = false;
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

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.ButtonText = "Đang đăng nhập...";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string realUserId = await SupabaseAuthService.SignInAsync(email, password);
                

                UserSession.Email = email;
                UserSession.DisplayName = email.Split('@')[0];
                UserSession.UserId = realUserId;

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                if (ex.Message == "ACCOUNT_NOT_FOUND")
                {
                    MessageBox.Show("Tài khoản chưa tồn tại, vui lòng đăng ký.", "Chưa có tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Message == "EMAIL_NOT_CONFIRMED")
                {
                    MessageBox.Show("Tài khoản chưa xác nhận email. Vui lòng mở hộp thư và bấm vào link xác nhận!", "Chưa kích hoạt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Message == "WRONG_CREDENTIALS")
                {
                    MessageBox.Show("Sai email hoặc mật khẩu.", "Đăng nhập chưa thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Chi tiết lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void HienThiMK_Click(object sender, EventArgs e)
        {
            dangHienMatKhau = !dangHienMatKhau;
            if (dangHienMatKhau == false )
            {
                txtPassword.Password = true;
                HienThiMK.Image = Properties.Resources.ic_closed_eye_25;
            }
            else
            {
                txtPassword.Password = false;
                
                HienThiMK.Image = Properties.Resources.ic_eye_25;
            }
        }

        
    }
}