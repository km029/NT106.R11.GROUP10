using System;
using System.Collections.Generic;
using System.Drawing;
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

        private const string PlaceholderText = "Tìm kiếm";
        private bool _isPlaceholder = true;

        public SearchControl()
        {
            InitializeComponent();
            _isPlaceholder = true;

            // Đồng bộ chữ gợi ý và màu sắc ngay khi khởi tạo
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
            lblStatus.Text = "Nhập username ID hoặc tên người dùng để tìm kiếm";

            // Bo tròn 4 góc thanh tìm kiếm ngay khi khởi tạo
            ApplyRoundedCorners(pnlSearch, 16);

            // Cập nhật lại vùng bo góc thanh tìm kiếm khi kích thước thay đổi
            pnlSearch.Resize += (s, e) => ApplyRoundedCorners(pnlSearch, 16);

            // Tự động co giãn chiều rộng các thẻ kết quả khi khung danh sách thay đổi kích thước
            Kqua.Resize += FlpResults_Resize;

            // Đăng ký các sự kiện nhập liệu và bộ đếm thời gian chống spam request (Debounce)
          //  txtSearch.GotFocus += TxtSearch_GotFocus;
           // txtSearch.LostFocus += TxtSearch_LostFocus;
           // txtSearch.TextChanged += TxtSearch_TextChanged;
           // Delay.Tick += DebounceTimer_Tick;
        }

        // Hàm bo tròn 4 góc cho Panel hoặc Control kèm giải phóng Region cũ
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

        // Điều chỉnh lại chiều rộng các thẻ UserItemCard khi phóng to/thu nhỏ cửa sổ
        private void FlpResults_Resize(object sender, EventArgs e)
        {
            int newWidth = Math.Max(200, Kqua.ClientSize.Width - 25);
            foreach (Control ctrl in Kqua.Controls)
            {
                if (ctrl is UserItemCard card)
                {
                    card.Width = newWidth;
                }
            }
        }

        // Xóa chữ gợi ý màu xám khi người dùng bấm vào ô tìm kiếm
        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                _isPlaceholder = false;
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        // Khôi phục chữ gợi ý nếu người dùng rời khỏi ô tìm kiếm mà chưa nhập gì
        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                _isPlaceholder = true;
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // Đặt lại đồng hồ đếm 500ms mỗi khi người dùng gõ phím mới
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        // Gửi yêu cầu tìm kiếm sau khi người dùng ngừng gõ đủ 500ms
        private async void DebounceTimer_Tick(object sender, EventArgs e)
        {
            Delay.Stop();
            await PerformSearchAsync();
        }

        // Gọi SupabaseFriendService để tìm người dùng và hiển thị bằng thẻ UserItemCard
        private async Task PerformSearchAsync()
        {
            if (_isPlaceholder)
                return;
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
                int cardWidth = Math.Max(200, Kqua.ClientSize.Width - 25);

                foreach (UserSearchResult user in users)
                {
                    UserItemCard card = new UserItemCard
                    {
                        Width = cardWidth,
                        Margin = new Padding(0, 0, 0, 8)
                    };
                    card.BindData(user);
                    Kqua.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi kết nối: " + ex.Message;
            }
        }
    }
}