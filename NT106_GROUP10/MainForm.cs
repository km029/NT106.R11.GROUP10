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
        private ProfileControl _profileControl;
        private SearchControl _search;
        private HomeControl _homeControl;
        private ReelsControl _reelsControl;
        private MessengerControl _messengerControl;
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
            Home_Click(Home, EventArgs.Empty);
        }

        // Hàm dùng chung để nhúng và chuyển đổi các trang vào panel bên phải
        private void ShowPage(UserControl page)
        {
            Content.SuspendLayout();
            // Nếu panel Content chưa chứa trang này thì thêm vào và cho giãn đầy khung
            if (!Content.Controls.Contains(page))
            {
                page.Dock = DockStyle.Fill;
                Content.Controls.Add(page);
            }
            // Đưa trang được chọn lên lớp trên cùng để hiển thị
            page.BringToFront();
            Content.ResumeLayout();
        }
        private void SelectTab(Button BamNut)
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
            BamNut.ForeColor = activeBlue;
            BamNut.Font = new Font(BamNut.Font, FontStyle.Bold);

            if (BamNut == Home)
                BamNut.Image = ColorizeIcon(Properties.Resources.ic_home_fill_36, activeBlue);
            else if (BamNut == Reels)
                BamNut.Image = ColorizeIcon(Properties.Resources.ic_reels_fill1, activeBlue);
            else if (BamNut == Messenger)
                BamNut.Image = ColorizeIcon(Properties.Resources.ic_messenger_fill, activeBlue);
            else if (BamNut == Search)
                BamNut.Image = ColorizeIcon(Properties.Resources.ic_search_fill, activeBlue);
            else if (BamNut == Profile)
                BamNut.Image = ColorizeIcon(Properties.Resources.ic_profile_fill_36, activeBlue);
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
            if (_homeControl==null)
            {
                _homeControl = new HomeControl();
            }
            ShowPage(_homeControl);

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            if (_profileControl == null)
            {
                _profileControl = new ProfileControl();
            }
            ShowPage(_profileControl);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (_search == null)
            {
                _search = new SearchControl();
            }
            ShowPage(_search);
        }

        private void Messenger_Click(object sender, EventArgs e)
        {
            if (_messengerControl == null)
            {
                _messengerControl = new MessengerControl();
            }
            ShowPage(_messengerControl);
        }

        private void Reels_Click(object sender, EventArgs e)
        {
            if (_reelsControl == null)
            {
                _reelsControl = new ReelsControl();
            }
            ShowPage(_reelsControl);
        }

        
    }
}
