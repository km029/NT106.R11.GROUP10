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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //Tạo bộ đệm để khi chạy vào giao diện đăng nhập không bị nháy khi đè ảnh mờ
             this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint |
                           ControlStyles.OptimizedDoubleBuffer, true);
           this.UpdateStyles();
            //Làm hiệu ứng trong suốt cho panel đăng nhập
            pnlLogin.BackColor = Color.FromArgb(220, 255, 255, 255);
        }
        protected override CreateParams CreateParams
       {
           get
            {
               CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
               return cp;
            }
        }
       

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.TextButton.Trim();
            string password = txtPassword.TextButton;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!");
                return;
            }
            // Vô hiệu hóa nút đăng nhập để tránh spawn và để hiệu ứng đang chạy
            btnLogin.Enabled = false;
            btnLogin.ButtonText = "Đang đăng nhập...";
            btnLogin.Invalidate();
            btnLogin.Update();
            // Hiển thị con trỏ chuột thành icon đang load
            this.Cursor = Cursors.WaitCursor;
            try
            {
                await SupabaseAuthService.SignInAsync(email, password);

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
            }
            catch(Exception)
{
                MessageBox.Show(
                    "Tài khoản hoặc mật khẩu không đúng",
                    "Đăng nhập chưa thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

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

       
    }
}