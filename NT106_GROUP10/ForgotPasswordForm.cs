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
        }

        private async void btnSendReset_Click(object sender, EventArgs e)
        {
            string email = txtRecoveryEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                txtRecoveryEmail.Focus();
                return;
            }

            btnSendReset.Enabled = false;

            try
            {
                await SupabaseAuthService.SendPasswordResetAsync(email);

                MessageBox.Show(
                    "Nếu email này có tài khoản, hãy kiểm tra hộp thư và nhập mã khôi phục.");

                using (var resetForm = new ResetPasswordForm(email))
                {
                    resetForm.ShowDialog(this);
                }
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
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}