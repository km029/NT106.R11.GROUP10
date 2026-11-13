using System;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
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

            string originalText = btnSendReset.ButtonText;
            btnSendReset.Enabled = false;
            btnSendReset.ButtonText = "Đang tải...";
            btnSendReset.Invalidate();
            btnSendReset.Update();
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await SupabaseAuthService.SendPasswordResetAsync(email);

                MessageBox.Show("Hãy kiểm tra hộp thư và nhập mã khôi phục.");
                this.Hide();
                ResetPasswordForm resetForm = new ResetPasswordForm(email);
                // Đặt form mới xuất hiện trùng khít vị trí form cũ để không bị nhảy khung hình
                resetForm.StartPosition = FormStartPosition.Manual;
                resetForm.Location = this.Location;

                resetForm.FormClosed += (s, args) => this.Close();
                // Gán Owner là LoginForm để Windows ép resetForm luôn nằm trên LoginForm
                Form loginForm = this.Owner ?? Application.OpenForms["LoginForm"];
                if (loginForm != null)
                    resetForm.Show(loginForm);
                else
                    resetForm.Show();

                this.Hide();
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