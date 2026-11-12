using System;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class ResetPasswordForm : Form
    {
        private readonly string _recoveryEmail;

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        public ResetPasswordForm(string email) : this()
        {
            _recoveryEmail = email;
        }

        

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            string code = txtResetCode.TextButton.Trim();
            string newPassword = txtNewPassword.TextButton;
            string confirmPassword = txtConfirmNewPassword.TextButton;

            if (string.IsNullOrWhiteSpace(_recoveryEmail))
            {
                MessageBox.Show(
                    "Không có email khôi phục. Hãy quay lại và yêu cầu mã mới.");
                return;
            }

            if (string.IsNullOrWhiteSpace(code) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập mã và đầy đủ mật khẩu mới.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Hai mật khẩu mới không khớp.");
                txtConfirmNewPassword.Text= "";
                txtConfirmNewPassword.Focus();
                return;
            }

            btnResetPassword.Enabled = false;

            try
            {
                await SupabaseAuthService.ResetPasswordAsync(
                    _recoveryEmail, code, newPassword);

                txtResetCode.Text = "";
                txtNewPassword.Text ="";
                txtConfirmNewPassword.Text = "";

                MessageBox.Show(
                    "Đặt lại mật khẩu thành công! Hãy đăng nhập bằng mật khẩu mới.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";

                MessageBox.Show(
                    ex.Message,
                    "Chưa đặt lại được mật khẩu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnResetPassword.Enabled = true;
            }
        }

        
    }
}