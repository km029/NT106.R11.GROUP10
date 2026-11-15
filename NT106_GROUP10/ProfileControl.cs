using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
            BoTronAvatar();
            BoGocButton(ChangeAvatar, 10);
            BoGocButton(EditProfile, 10);
            CanGiuaKhungChinh();
            this.Resize += (s, e) => CanGiuaKhungChinh();
        }
        private void BoTronAvatar()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, Avatar.Width, Avatar.Height);
            Avatar.Region = new Region(path);
        }
        // Hàm bo tròn 4 góc cho nút
        private void BoGocButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(btn.Width - d, 0, d, d, 270, 90);
            path.AddArc(btn.Width - d, btn.Height - d, d, d, 0, 90);
            path.AddArc(0, btn.Height - d, d, d, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
        private void CanGiuaKhungChinh()
        {
            Card.Left = Math.Max(0, (this.ClientSize.Width - Card.Width) / 2);
            Card.Top = Math.Max(0, (this.ClientSize.Height - Card.Height) / 2);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTabInfo_Click(object sender, EventArgs e)
        {
            pnlIndicator.Width = btnTabInfo.Width;
            pnlIndicator.Left = btnTabInfo.Left;

            flpContent.Controls.Clear();

            // Khai báo danh sách thông tin chuẩn chỉnh từng dòng
            string[,] infos = new string[,]
            {
        { "📧 Email đăng nhập", UserSession.Email },
        { "🆔 Mã định danh (UID)", UserSession.UserId },
        { "👤 Tên hiển thị", string.IsNullOrEmpty(UserSession.DisplayName) ? "Chưa cập nhật" : UserSession.DisplayName },
        { "🎯 Trạng thái tài khoản", "Đang hoạt động trên Supabase" }
            };

            for (int i = 0; i < infos.GetLength(0); i++)
            {
                Panel pnlItem = new Panel();
                // Lấy theo chiều rộng của thẻ Card lớn bọc bên ngoài thay vì lấy flpContent đang bị bóp nhỏ
                pnlItem.Width = Card.Width - 60;
                pnlItem.Height = 60;
                pnlItem.BackColor = Color.FromArgb(245, 247, 250);
                pnlItem.Margin = new Padding(10, 5, 10, 5);

                Label lblTitle = new Label();
                lblTitle.Text = infos[i, 0];
                lblTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(90, 105, 120);
                lblTitle.Location = new Point(15, 10);
                lblTitle.AutoSize = true;

                Label lblValue = new Label();
                lblValue.Text = infos[i, 1];
                lblValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                lblValue.ForeColor = Color.FromArgb(30, 40, 50);
                lblValue.Location = new Point(15, 32);
                lblValue.AutoSize = true;

                pnlItem.Controls.Add(lblTitle);
                pnlItem.Controls.Add(lblValue);
                flpContent.Controls.Add(pnlItem);
            }
        }

        private void btnTabFriends_Click(object sender, EventArgs e)
        {
            pnlIndicator.Width = btnTabFriends.Width;
            pnlIndicator.Left = btnTabFriends.Left;
        }

        private void pnlIndicator_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
