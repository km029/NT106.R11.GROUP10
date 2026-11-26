using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class UserItemCard : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private static readonly HttpClient ImageHttp = new HttpClient();
        private UserSearchResult _user;

        public UserItemCard()
        {
            InitializeComponent();

            // Bo tròn khung thẻ, nút bấm và cắt tròn avatar
            this.Resize += (s, e) => ApplyRoundedCorners(this, 12);
            ApplyRoundedCorners(this, 12);
            MakeAvatarCircle(picAvatar);
        }

        // Hàm nhận dữ liệu từ SearchControl và đổ lên giao diện
        internal void BindData(UserSearchResult user)
        {
            _user = user;

            // 1. Hiển thị tên và trạng thái online
            string titleText = string.IsNullOrWhiteSpace(user.DisplayName) ? user.Username : user.DisplayName;
            if (user.Status == "online")
                titleText += "  ●";

            lblName.Text = titleText;
            lblName.ForeColor = user.Status == "online" ? Color.FromArgb(0, 150, 80) : Color.Black;
            lblUsername.Text = "@" + user.Username;

            // 2. Tải ảnh đại diện nếu có
            if (!string.IsNullOrEmpty(user.AvatarUrl))
                LoadAvatarAsync(user.AvatarUrl);

            // 3. Cập nhật màu sắc và chữ cho nút Kết bạn
            UpdateActionButton(user.FriendStatus);
        }

        // Sự kiện khi người dùng bấm nút Kết bạn / Chấp nhận / Hủy lời mời
        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            // Bỏ focus khỏi nút ngay khi bấm để Windows không vẽ khung viền focus lệch màu
            this.ActiveControl = null;
            btnAction.Enabled = false;

            try
            {
                if (_user.FriendStatus == "none" || string.IsNullOrEmpty(_user.FriendStatus))
                {
                    // gửi lời mời kb
                    string newFriendshipId = await SupabaseFriendService.SendFriendRequestAsync(_user.Id);
                    _user.FriendshipId = newFriendshipId;
                    _user.FriendStatus = "pending_sent";
                }
                else if (_user.FriendStatus == "pending_received")
                {
                    // chấp nhận
                    await SupabaseFriendService.AcceptFriendRequestAsync(_user.FriendshipId, _user.Id);
                    _user.FriendStatus = "accepted";
                }
                else if (_user.FriendStatus == "pending_sent")
                {
                    // Hỏi xác nhận trước khi hủy lời mời đã gửi
                    DialogResult confirm = MessageBox.Show(
                        $"Bạn có muốn hủy lời mời kết bạn đã gửi cho @{_user.Username}?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        await SupabaseFriendService.CancelFriendRequestAsync(_user.FriendshipId, _user.Id);
                        _user.FriendshipId = null;
                        _user.FriendStatus = "none";
                    }
                }

                UpdateActionButton(_user.FriendStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAction.Enabled = true;
            }
        }

        private void UpdateActionButton(string friendStatus)
        {
            btnAction.FlatStyle = FlatStyle.Flat;
            btnAction.UseVisualStyleBackColor = false;
            btnAction.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAction.TextAlign = ContentAlignment.MiddleCenter;

            switch (friendStatus)
            {
                case "accepted":
                    btnAction.Text = "Bạn bè";
                    btnAction.BackColor = Color.FromArgb(240, 242, 245);
                    btnAction.ForeColor = Color.FromArgb(28, 30, 33);
                    btnAction.FlatAppearance.BorderSize = 1;
                    btnAction.FlatAppearance.BorderColor = Color.FromArgb(216, 218, 223);
                    btnAction.FlatAppearance.MouseOverBackColor = Color.FromArgb(228, 230, 235);
                    btnAction.FlatAppearance.MouseDownBackColor = Color.FromArgb(216, 218, 223);
                    break;

                case "pending_sent":
                    btnAction.Text = "Đã gửi lời mời";
                    btnAction.BackColor = Color.FromArgb(240, 242, 245);
                    btnAction.ForeColor = Color.FromArgb(101, 103, 107);
                    btnAction.FlatAppearance.BorderSize = 1;
                    btnAction.FlatAppearance.BorderColor = Color.FromArgb(216, 218, 223);
                    btnAction.FlatAppearance.MouseOverBackColor = Color.FromArgb(228, 230, 235);
                    btnAction.FlatAppearance.MouseDownBackColor = Color.FromArgb(216, 218, 223);
                    break;

                case "pending_received":
                    btnAction.Text = "Chấp nhận";
                    btnAction.BackColor = Color.FromArgb(0, 149, 246);
                    btnAction.ForeColor = Color.White;
                    btnAction.FlatAppearance.BorderSize = 0;
                    btnAction.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
                    btnAction.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 100, 210);
                    break;

                default:
                    btnAction.Text = "Kết bạn";
                    btnAction.BackColor = Color.FromArgb(0, 149, 246);
                    btnAction.ForeColor = Color.White;
                    btnAction.FlatAppearance.BorderSize = 0;
                    btnAction.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 119, 242);
                    btnAction.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 100, 210);
                    break;
            }
        }

        private void MakeAvatarCircle(PictureBox pic)
        {
            if (pic == null || pic.Width <= 0 || pic.Height <= 0) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pic.Width, pic.Height);
                Region oldRegion = pic.Region;
                pic.Region = new Region(path);
                if (oldRegion != null) oldRegion.Dispose();
            }
        }

        private void ApplyRoundedCorners(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;

            IntPtr ptr = CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, radius, radius);
            Region oldRegion = ctrl.Region;
            ctrl.Region = Region.FromHrgn(ptr);
            if (oldRegion != null) oldRegion.Dispose();
        }

        private async void LoadAvatarAsync(string url)
        {
            try
            {
                byte[] bytes = await ImageHttp.GetByteArrayAsync(url);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    if (!picAvatar.IsDisposed)
                        picAvatar.Image = Image.FromStream(ms);
                }
            }
            catch { }
        }
    }
}