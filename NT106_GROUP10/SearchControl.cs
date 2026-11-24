using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;       // Dùng cho GraphicsPath để bo tròn ảnh đại diện
using System.IO;                      // Dùng cho MemoryStream đọc dữ liệu ảnh tải từ mạng
using System.Net.Http;
using System.Runtime.InteropServices; // Dùng cho DllImport gọi hàm bo góc của Windows
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class SearchControl : UserControl
    {
        // Nhập hàm API từ thư viện Gdi32.dll của Windows để tạo vùng bo tròn 4 góc
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // Bộ tải ảnh đại diện dùng chung cho toàn bộ control
        private static readonly HttpClient ImageHttp = new HttpClient();

        // Văn bản gợi ý mặc định hiển thị trong ô tìm kiếm
        private const string PlaceholderText = "Tìm kiếm theo username hoặc tên...";

        public SearchControl()
        {
            InitializeComponent();

            // Bo tròn 4 góc thanh tìm kiếm ngay khi khởi tạo
            ApplyRoundedCorners(pnlSearch, 16);

            // Cập nhật lại vùng bo góc thanh tìm kiếm khi kích thước thay đổi
            pnlSearch.Resize += (s, e) => ApplyRoundedCorners(pnlSearch, 16);

            // Tự động co giãn chiều rộng các thẻ kết quả khi khung danh sách thay đổi kích thước
            Kqua.Resize += FlpResults_Resize;

            // Đăng ký các sự kiện nhập liệu và bộ đếm thời gian chống spam request (Debounce)
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            Delay.Tick += DebounceTimer_Tick;
        }

        // Hàm cắt bo tròn hình tròn cho PictureBox (chống rò rỉ bộ nhớ GDI và lỗi kích thước <= 0)
        private void MakeAvatarCircle(PictureBox pic)
        {
            if (pic == null || pic.Width <= 0 || pic.Height <= 0)
                return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pic.Width, pic.Height);

                Region oldRegion = pic.Region;
                pic.Region = new Region(path);

                if (oldRegion != null)
                    oldRegion.Dispose();
            }
        }

        // Hàm bo tròn 4 góc cho Panel hoặc Button kèm giải phóng Region cũ
        private void ApplyRoundedCorners(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0)
                return;

            IntPtr ptr = CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, radius, radius);
            Region oldRegion = ctrl.Region;
            ctrl.Region = Region.FromHrgn(ptr);

            if (oldRegion != null)
                oldRegion.Dispose();
        }

        // Điều chỉnh lại chiều rộng các thẻ kết quả khi phóng to/thu nhỏ cửa sổ
        private void FlpResults_Resize(object sender, EventArgs e)
        {
            int newWidth = Math.Max(200, Kqua.ClientSize.Width - 25);
            foreach (Control ctrl in Kqua.Controls)
            {
                if (ctrl is Panel card)
                {
                    card.Width = newWidth;
                    ApplyRoundedCorners(card, 12);

                    // Giữ nút hành động luôn nằm sát mép phải thẻ
                    foreach (Control child in card.Controls)
                    {
                        if (child is Button btn)
                            btn.Left = card.Width - btn.Width - 15;
                    }
                }
            }
        }

        // Xóa chữ gợi ý màu xám khi người dùng bấm vào ô tìm kiếm
        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        // Khôi phục chữ gợi ý nếu người dùng rời khỏi ô tìm kiếm mà chưa nhập gì
        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // Đặt lại đồng hồ đếm 400ms mỗi khi người dùng gõ phím mới
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == Color.Gray)
                return;

            Delay.Stop();

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                Kqua.Controls.Clear();
                lblStatus.Text = "Nhập tên người dùng để bắt đầu tìm kiếm.";
                return;
            }

            lblStatus.Text = "Đang gõ...";
            Delay.Start();
        }

        // Gửi yêu cầu tìm kiếm sau khi người dùng ngừng gõ đủ 400ms
        private async void DebounceTimer_Tick(object sender, EventArgs e)
        {
            Delay.Stop();
            await PerformSearchAsync();
        }

        // Gọi SupabaseFriendService để tìm người dùng và hiển thị danh sách kết quả
        private async Task PerformSearchAsync()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword) || txtSearch.ForeColor == Color.Gray)
                return;

            lblStatus.Text = "Đang tìm kiếm...";
            Kqua.Controls.Clear();

            try
            {
                List<UserSearchResult> users = await SupabaseFriendService.SearchUsersAsync(keyword);

                if (users.Count == 0)
                {
                    lblStatus.Text = "Không tìm thấy người dùng nào phù hợp với \"" + keyword + "\".";
                    return;
                }

                lblStatus.Text = "Tìm thấy " + users.Count + " kết quả:";
                foreach (UserSearchResult user in users)
                {
                    Kqua.Controls.Add(CreateUserItemCard(user));
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi kết nối: " + ex.Message;
            }
        }

        // Tạo thẻ giao diện hiển thị thông tin từng người dùng
        private Panel CreateUserItemCard(UserSearchResult user)
        {
            int cardWidth = Math.Max(200, Kqua.ClientSize.Width - 25);

            Panel card = new Panel
            {
                Width = cardWidth,
                Height = 68,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = Color.FromArgb(250, 250, 250)
            };
            ApplyRoundedCorners(card, 12);

            // Ảnh đại diện hình vuông 48x48 và cắt tròn bằng MakeAvatarCircle
            PictureBox picAvatar = new PictureBox
            {
                Size = new Size(48, 48),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray,
                Image = Properties.Resources.ic_profile_fill_36
            };
            MakeAvatarCircle(picAvatar);

            // Tải ảnh đại diện thật từ URL nếu người dùng đã cập nhật avatar
            if (!string.IsNullOrEmpty(user.AvatarUrl))
                LoadAvatarAsync(picAvatar, user.AvatarUrl);

            // Tên hiển thị kèm chấm xanh nếu đang online
            string titleText = string.IsNullOrWhiteSpace(user.DisplayName) ? user.Username : user.DisplayName;
            if (user.Status == "online")
                titleText += "  ●";

            Label lblName = new Label
            {
                Text = titleText,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = user.Status == "online" ? Color.FromArgb(0, 150, 80) : Color.Black,
                AutoSize = true,
                Location = new Point(70, 12)
            };

            // Dòng @username phụ bên dưới
            Label lblUsername = new Label
            {
                Text = "@" + user.Username,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(70, 35)
            };

            // Nút hành động kết bạn ở bên phải thẻ
            Button btnAction = new Button
            {
                Size = new Size(125, 32),
                Location = new Point(card.Width - 140, 18),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnAction.FlatAppearance.BorderSize = 0;
            ApplyRoundedCorners(btnAction, 10);
            ApplyFriendButtonStyle(btnAction, user.FriendStatus);

            card.Controls.Add(picAvatar);
            card.Controls.Add(lblName);
            card.Controls.Add(lblUsername);
            card.Controls.Add(btnAction);

            return card;
        }

        // Đổi nhãn và màu nút dựa theo trạng thái quan hệ bạn bè
        private void ApplyFriendButtonStyle(Button btn, string friendStatus)
        {
            switch (friendStatus)
            {
                case "accepted":
                    btn.Text = "Bạn bè";
                    btn.BackColor = Color.FromArgb(239, 239, 239);
                    btn.ForeColor = Color.Black;
                    break;
                case "pending_sent":
                    btn.Text = "Đã gửi lời mời";
                    btn.BackColor = Color.FromArgb(239, 239, 239);
                    btn.ForeColor = Color.DimGray;
                    break;
                case "pending_received":
                    btn.Text = "Chấp nhận";
                    btn.BackColor = Color.FromArgb(0, 149, 246);
                    btn.ForeColor = Color.White;
                    break;
                default:
                    btn.Text = "Kết bạn";
                    btn.BackColor = Color.FromArgb(0, 149, 246);
                    btn.ForeColor = Color.White;
                    break;
            }
        }

        // Tải ảnh đại diện từ mạng bất đồng bộ để không làm treo giao diện
        private async void LoadAvatarAsync(PictureBox pic, string url)
        {
            try
            {
                byte[] bytes = await ImageHttp.GetByteArrayAsync(url);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    if (!pic.IsDisposed)
                        pic.Image = Image.FromStream(ms);
                }
            }
            catch { }
        }
    }
}