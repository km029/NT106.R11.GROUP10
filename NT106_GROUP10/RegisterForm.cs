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

        private void btnDoRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả các thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp! Vui lòng nhập lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

           
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            using (Microsoft.Data.SqlClient.SqlConnection conn =
                   new Microsoft.Data.SqlClient.SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery =
                        "SELECT COUNT(*) FROM Users " +
                        "WHERE Username = @Username OR Email = @Email";

                    using (Microsoft.Data.SqlClient.SqlCommand checkCmd =
                           new Microsoft.Data.SqlClient.SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        checkCmd.Parameters.AddWithValue("@Email", email);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Tên đăng nhập hoặc Email này đã tồn tại trong hệ thống!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery =
                        "INSERT INTO Users " +
                        "(Username, Email, PasswordHash, CreatedAt) " +
                        "VALUES (@Username, @Email, @PasswordHash, SYSDATETIME())";

                    using (Microsoft.Data.SqlClient.SqlCommand insertCmd =
                           new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Đăng ký tài khoản thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
