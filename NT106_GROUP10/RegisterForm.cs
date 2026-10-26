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
            txtRegPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private async void btnDoRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            btnDoRegister.Enabled = false;

            try
            {
                await SupabaseAuthService.SignUpAsync(username, email, password);

                MessageBox.Show(
                    "Đã gửi yêu cầu đăng ký. Hãy kiểm tra email xác nhận nếu được yêu cầu.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký chưa thành công: " + ex.Message);
            }
            finally
            {
                btnDoRegister.Enabled = true;
            }
        }
        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
