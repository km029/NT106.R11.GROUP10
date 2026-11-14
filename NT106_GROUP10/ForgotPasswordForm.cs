using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            EnableDoubleBufferRecursive(this);
        }

        private static void EnableDoubleBufferRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, ctrl, new object[] { true });

                if (ctrl is Panel && ctrl.BackColor.A < 255 && ctrl.BackColor != Color.Transparent)
                {
                    ctrl.BackColor = Color.White;
                }

                if (ctrl.HasChildren)
                {
                    EnableDoubleBufferRecursive(ctrl);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSendReset_Click(object sender, EventArgs e)
        {
            string email = txtRecoveryEmail.TextButton.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                txtRecoveryEmail.Focus();
                return;
            }

            // 1. Kiểm tra định dạng email có @
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Định dạng email không hợp lệ (phải có @ và tên miền).",
                    "Lỗi định dạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtRecoveryEmail.Focus();
                return;
            }

            string originalText = btnSendReset.ButtonText;
            btnSendReset.Enabled = false;
            btnSendReset.ButtonText = "Đang kiểm tra...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // 2. Kiểm tra email đã tồn tại trong hệ thống chưa
                bool emailExists = await SupabaseAuthService.AccountExistsAsync(email);
                if (!emailExists)
                {
                    var askRegister = MessageBox.Show(
                        "Email này chưa tồn tại trong hệ thống. Bạn có muốn chuyển sang trang Đăng ký tạo tài khoản mới không?",
                        "Email chưa đăng ký",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (askRegister == DialogResult.Yes)
                    {
                        using (var regForm = new RegisterForm())
                        {
                            regForm.ShowDialog(this);
                        }
                    }
                    return;
                }

                // 3. Nếu đã đăng ký -> gửi mã xác thực
                btnSendReset.ButtonText = "Đang gửi mã...";
                await SupabaseAuthService.SendPasswordResetAsync(email);

                MessageBox.Show(
                    "Đã gửi mã xác thực, vui lòng kiểm tra email.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Hide();
                ResetPasswordForm resetForm = new ResetPasswordForm(email);
                resetForm.StartPosition = FormStartPosition.Manual;
                resetForm.Location = this.Location;
                resetForm.FormClosed += (s, args) => this.Close();

                Form loginForm = this.Owner ?? Application.OpenForms["LoginForm"];
                if (loginForm != null)
                    resetForm.Show(loginForm);
                else
                    resetForm.Show();

                resetForm.BringToFront();
                resetForm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Chưa gửi được yêu cầu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSendReset.Enabled = true;
                btnSendReset.ButtonText = originalText;
                this.Cursor = Cursors.Default;
            }
        }
    }
}