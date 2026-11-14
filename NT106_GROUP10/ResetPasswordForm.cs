using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class ResetPasswordForm : Form
    {
        private readonly string _recoveryEmail;

        public ResetPasswordForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            EnableDoubleBufferRecursive(this);
        }

        public ResetPasswordForm(string email) : this()
        {
            _recoveryEmail = email;
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

            // Kiểm tra định dạng mật khẩu mới: >= 8 ký tự, hoa, thường, số, ký tự đặc biệt
            if (!SupabaseAuthService.IsValidPassword(newPassword))
            {
                MessageBox.Show(
                    "Mật khẩu mới phải có tối thiểu 8 ký tự, bao gồm: chữ hoa, chữ thường, chữ số và ký tự đặc biệt.",
                    "Mật khẩu chưa đạt yêu cầu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Hai mật khẩu mới không khớp.");
                txtConfirmNewPassword.TextButton = "";
                txtConfirmNewPassword.Focus();
                return;
            }

            string originalText = btnResetPassword.ButtonText;

            btnResetPassword.Enabled = false;
            btnResetPassword.ButtonText = "Đang đặt lại mật khẩu...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await SupabaseAuthService.ResetPasswordAsync(
                    _recoveryEmail, code, newPassword);

                txtResetCode.TextButton = "";
                txtNewPassword.TextButton = "";
                txtConfirmNewPassword.TextButton = "";

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
                txtNewPassword.TextButton = "";
                txtConfirmNewPassword.TextButton = "";

                MessageBox.Show(
                    ex.Message,
                    "Chưa đặt lại được mật khẩu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnResetPassword.Enabled = true;
                btnResetPassword.ButtonText = originalText;
                this.Cursor = Cursors.Default;
            }
        }
    }
}