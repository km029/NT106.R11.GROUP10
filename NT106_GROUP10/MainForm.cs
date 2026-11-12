using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class MainForm : Form
    {
        //Hàm hệ thống hỗ trợ bo tròn góc
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private readonly Color activeBlue = Color.FromArgb(0, 149, 246);
        public MainForm()
        {
            InitializeComponent();

            // Bo tròn nhẹ 4 góc (14px) cho cả 6 nút
            Button[] allButtons = { Home, Reels, Messenger, Search, Profile, Logout };
            foreach (Button btn in allButtons)
            {
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 14, 14));
            }
            // Giữ nút Logout màu đen mặc định
            Logout.ForeColor = Color.Black;
            Logout.Image = Properties.Resources.ic_logout_line_36;
            //  Gắn sự kiện click cho 5 tab điều hướng
            Home.Click += (s, e) => SelectTab(Home);
            Reels.Click += (s, e) => SelectTab(Reels);
            Messenger.Click += (s, e) => SelectTab(Messenger);
            Search.Click += (s, e) => SelectTab(Search);
            Profile.Click += (s, e) => SelectTab(Profile);
            // Mặc định chọn sẵn Trang chủ khi mở app
            SelectTab(Home);
        }
        private void SelectTab(Button activeBtn)
        {
            // Đưa cả 5 tab về trạng thái bình thường: chữ đen thường + icon nét mảnh đen gốc
            Home.ForeColor = Color.Black;
            Home.Font = new Font(Home.Font, FontStyle.Regular);
            Home.Image = Properties.Resources.ic_home_line_36;

            Reels.ForeColor = Color.Black;
            Reels.Font = new Font(Reels.Font, FontStyle.Regular);
            Reels.Image = Properties.Resources.ic_reels_line1;

            Messenger.ForeColor = Color.Black;
            Messenger.Font = new Font(Messenger.Font, FontStyle.Regular);
            Messenger.Image = Properties.Resources.ic_messenger_line;

            Search.ForeColor = Color.Black;
            Search.Font = new Font(Search.Font, FontStyle.Regular);
            Search.Image = Properties.Resources.ic_search_line;

            Profile.ForeColor = Color.Black;
            Profile.Font = new Font(Profile.Font, FontStyle.Regular);
            Profile.Image = Properties.Resources.ic_profile_line_36;

            // Tô xanh (0, 149, 246) + in đậm chữ + đổi icon đặc (fill) cho tab đang chọn
            activeBtn.ForeColor = activeBlue;
            activeBtn.Font = new Font(activeBtn.Font, FontStyle.Bold);

            if (activeBtn == Home)
                activeBtn.Image = ColorizeIcon(Properties.Resources.ic_home_fill_36, activeBlue);
            else if (activeBtn == Reels)
                activeBtn.Image = ColorizeIcon(Properties.Resources.ic_reels_fill1, activeBlue);
            else if (activeBtn == Messenger)
                activeBtn.Image = ColorizeIcon(Properties.Resources.ic_messenger_fill, activeBlue);
            else if (activeBtn == Search)
                activeBtn.Image = ColorizeIcon(Properties.Resources.ic_search_fill, activeBlue);
            else if (activeBtn == Profile)
                activeBtn.Image = ColorizeIcon(Properties.Resources.ic_profile_fill_36, activeBlue);
        }
        private Bitmap ColorizeIcon(Image original, Color targetColor)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);
            float r = targetColor.R / 255f;
            float g = targetColor.G / 255f;
            float b = targetColor.B / 255f;

            float[][] matrix = {
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {r, g, b, 0, 1}
            };

            using (Graphics gr = Graphics.FromImage(bmp))
            using (ImageAttributes attr = new ImageAttributes())
            {
                attr.SetColorMatrix(new ColorMatrix(matrix));
                gr.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel, attr);
            }
            return bmp;
        }
        bool NhanNutDangXuat = false;

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!NhanNutDangXuat) 
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            DialogResult DangXuat = MessageBox.Show("Đăng xuất khỏi tài khoản của bạn?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DangXuat==DialogResult.Yes)
            {
                NhanNutDangXuat = true;
                LoginForm Login = new LoginForm();
                Login.Show();
                this.Close();
            }    
        }

        private void Home_Click(object sender, EventArgs e)
        {
     
     
        }

        
    }
}
