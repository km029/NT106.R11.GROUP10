using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            
        }

        private async void btnDoRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.TextButton.Trim();
            string email = txtRegEmail.TextButton.Trim();
            string password = txtRegPassword.TextButton;
            string confirmPassword = txtConfirmPassword.TextButton;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // 1. Kiểm tra định dạng email hợp lệ
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng email không hợp lệ.");
                txtRegEmail.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            // Vô hiệu hóa nút đăng ký để tránh bấm nhiều lần và hiển thị trạng thái đang chạy
            btnDoRegister.Enabled = false;
            btnDoRegister.ButtonText = "Đang đăng ký...";
            btnDoRegister.Invalidate();
            btnDoRegister.Update();
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // 2. Gọi API đăng ký xong rồi mới hiện thông báo thành công
                await SupabaseAuthService.SignUpAsync(username, email, password);

                MessageBox.Show(
                    "Đã gửi yêu cầu đăng ký. Hãy kiểm tra hộp thư email để xác nhận yêu cầu.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Đăng ký chưa thành công",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnDoRegister.Enabled = true;
                btnDoRegister.ButtonText = "Đăng ký tài khoản";
                this.Cursor = Cursors.Default;
            }
        }
        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
