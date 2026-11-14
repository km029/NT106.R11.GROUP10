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


    }
}
