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
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
            this.Resize += (s, e) => CanGiuaKhungChinh();
        }
        private void CanGiuaKhungChinh()
        {
            Card.Left = Math.Max(0, (this.ClientSize.Width - Card.Width) / 2);
            Card.Top = Math.Max(0, (this.ClientSize.Height - Card.Height) / 2);
        }
    }
}
