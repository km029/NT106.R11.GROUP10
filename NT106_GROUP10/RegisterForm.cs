using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // Bật DoubleBuffered cho toàn bộ Panel, nút bấm và ô nhập trên Form
            EnableDoubleBufferRecursive(this);
        }

        private static void EnableDoubleBufferRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, ctrl, new object[] { true });

                // Nếu có Panel đang để màu bán trong suốt (Alpha < 255) thì chuyển về màu đặc để hết lag
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

            if (username.Length < 3 || username.Contains("@") || username.Contains(" "))
            {
                MessageBox.Show("Username phải từ 3 ký tự trở lên, không chứa dấu cách hoặc ký tự @.");
                txtRegUsername.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng email không hợp lệ.");
                txtRegEmail.Focus();
                return;
            }

            if (!SupabaseAuthService.IsValidPassword(password))
            {
                MessageBox.Show(
                    "Mật khẩu phải có tối thiểu 8 ký tự, bao gồm: chữ hoa, chữ thường, chữ số và ký tự đặc biệt.",
                    "Mật khẩu chưa đạt yêu cầu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtRegPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                txtConfirmPassword.Focus();
                return;
            }

            btnDoRegister.Enabled = false;
            btnDoRegister.ButtonText = "Đang đăng ký...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string duplicateStatus = await SupabaseAuthService.CheckDuplicateAsync(username, email);

                if (duplicateStatus == "USERNAME_EXISTS")
                {
                    MessageBox.Show("Username này đã có người sử dụng, vui lòng chọn tên khác.", "Trùng Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRegUsername.Focus();
                    return;
                }

                if (duplicateStatus == "EMAIL_EXISTS")
                {
                    MessageBox.Show("Email này đã được đăng ký, vui lòng dùng email khác.", "Trùng Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRegEmail.Focus();
                    return;
                }

                await SupabaseAuthService.SignUpAsync(username, email, password);

                MessageBox.Show(
                    "Đã tạo tài khoản thành công, vui lòng dùng tên đăng nhập (hoặc email) và mật khẩu để đăng nhập.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                string msg = "Đăng ký chưa thành công.";
                if (ex.Message.Contains("Database error saving new user"))
                    msg = "Username hoặc Email này đã tồn tại.";
                else if (ex.Message.Contains("User already registered"))
                    msg = "Email này đã được đăng ký.";
                else if (ex.Message.IndexOf("rate limit", StringComparison.OrdinalIgnoreCase) >= 0)
                    msg = "Bạn thao tác quá nhanh, vui lòng thử lại sau.";

                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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