using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class EditProfileControl : UserControl
    {
        private string oldUsername = "";
        
        public event Action<string, string, string, string> ProfileUpdated;
        public event Action Cancelled;

        public EditProfileControl()
        {
            InitializeComponent();
            SetupInstaStyle();
        }

        private void SetupInstaStyle()
        {
            SetRounded(btnSave, 10);
            SetRounded(btnBack, 10);
            SetRounded(pnlDisplayNameBox, 14);
            SetRounded(pnlUsernameBox, 14);
            SetRounded(pnlBioBox, 14);
            SetRounded(pnlGenderBox, 14);

            pnlBioBox.Paint += (s, e) => DrawBorder(pnlBioBox, e.Graphics, 14);
            pnlGenderBox.Paint += (s, e) => DrawBorder(pnlGenderBox, e.Graphics, 14);

            if (cboGender.Items.Count > 0)
                cboGender.SelectedIndex = 0;
        }

        public void LoadData(string username, string displayName, string bio = "", string gender = "Không muốn tiết lộ")
        {
            oldUsername = username ?? "";
            txtUsername.Text = oldUsername;
            txtDisplayName.Text = displayName ?? "";
            txtBio.Text = bio ?? "";

            int idx = cboGender.Items.IndexOf(string.IsNullOrWhiteSpace(gender) ? "Không muốn tiết lộ" : gender);
            cboGender.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cancelled?.Invoke();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string newUser = txtUsername.Text.Trim();
            string newName = txtDisplayName.Text.Trim();
            string newBio = txtBio.Text.Trim();
            string newGender = cboGender.SelectedItem?.ToString() ?? "Không muốn tiết lộ";

            if (newUser.Length < 3 || newUser.Contains("@") || newUser.Contains(" "))
            {
                MessageBox.Show(
                    "Username phải từ 3 ký tự trở lên, không chứa dấu cách hoặc ký tự @.",
                    "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên hiển thị.",
                    "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return;
            }

            btnSave.Enabled = false;
            btnBack.Enabled = false;
            btnSave.Text = "Đang lưu...";
            Cursor = Cursors.WaitCursor;

            try
            {
                if (!string.Equals(newUser, oldUsername, StringComparison.OrdinalIgnoreCase))
                {
                    bool exists = await SupabaseAuthService.AccountExistsAsync(newUser);
                    if (exists)
                    {
                        MessageBox.Show(
                            "Username này đã có người sử dụng, vui lòng chọn tên khác.",
                            "Trùng Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Focus();
                        return;
                    }
                }

                // Nếu hàm UpdateProfileAsync của bạn hỗ trợ thêm bio/gender thì truyền thêm ở đây
                await SupabaseAuthService.UpdateProfileAsync(newUser, newName);

                UserSession.DisplayName = newName;
                ProfileUpdated?.Invoke(newUser, newName, newBio, newGender);

                MessageBox.Show(
                    "Đã cập nhật thông tin trang cá nhân!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật thông tin:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnSave.Enabled = true;
                    btnBack.Enabled = true;
                    btnSave.Text = "Lưu thay đổi";
                    Cursor = Cursors.Default;
                }
            }
        }

        private void SetRounded(Control c, int radius)
        {
            void Apply()
            {
                if (c.Width <= 0 || c.Height <= 0) return;
                using (GraphicsPath path = GetRoundPath(new Rectangle(0, 0, c.Width, c.Height), radius))
                {
                    Region old = c.Region;
                    c.Region = new Region(path);
                    old?.Dispose();
                }
            }
            Apply();
            c.Resize += (s, e) => Apply();
        }

        private void DrawBorder(Control c, Graphics g, int radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.FromArgb(219, 223, 230), 1.2f))
            using (GraphicsPath path = GetRoundPath(new Rectangle(0, 0, c.Width - 1, c.Height - 1), radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}