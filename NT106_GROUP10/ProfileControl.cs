using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace NT106_GROUP10
{
    public partial class ProfileControl : UserControl
    {
        private readonly Color blue = Color.FromArgb(48, 116, 235);
        private readonly Color dark = Color.FromArgb(35, 51, 75);
        private readonly Color muted = Color.FromArgb(100, 116, 139);
        private readonly Color lightBlue = Color.FromArgb(246, 249, 255);

        private string currentEmail = "";
        private string currentUID = "";
        private string currentDisplayName = "";
        private string currentUsername = "";

        public ProfileControl()
        {
            InitializeComponent();

            SetupDesign();
            BindEvents();
            LoadCurrentUser();
            ShowInfoTab();

            this.Resize += (s, e) => CenterCard();
            CenterCard();
        }

        // =========================
        // GIAO DIỆN
        // =========================

        private void SetupDesign()
        {
            this.BackColor = Color.FromArgb(244, 247, 252);

            Card.BackColor = Color.White;
            SetRounded(Card, 24);

            Avatar.SizeMode = PictureBoxSizeMode.Zoom;
            Avatar.BackColor = Color.FromArgb(226, 232, 240);
            MakeAvatarCircle();
            Avatar.Resize += (s, e) => MakeAvatarCircle();

            // Dòng tên trên cùng: Username đăng nhập
            lblUsername.ForeColor = dark;
            lblUsername.Font = new Font("Segoe UI", 25, FontStyle.Bold);

            // Dòng tên thứ 2: Tên tài khoản (cùng font & màu với username, nhỏ hơn xíu, không icon thư, không nền xanh)
            lblAccountName.BackColor = Color.Transparent;
            lblAccountName.ForeColor = dark;
            lblAccountName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblAccountName.Region = null;

            lblPostsCount.ForeColor = blue;
            lblFriendsCount.ForeColor = dark;

            ChangeAvatar.BackColor = blue;
            ChangeAvatar.ForeColor = Color.White;
            ChangeAvatar.FlatStyle = FlatStyle.Flat;
            ChangeAvatar.FlatAppearance.BorderSize = 0;
            SetRounded(ChangeAvatar, 12);

            EditProfile.BackColor = Color.FromArgb(235, 243, 255);
            EditProfile.ForeColor = blue;
            EditProfile.FlatStyle = FlatStyle.Flat;
            EditProfile.FlatAppearance.BorderSize = 0;
            SetRounded(EditProfile, 12);

            btnTabInfo.FlatStyle = FlatStyle.Flat;
            btnTabFriends.FlatStyle = FlatStyle.Flat;
            btnTabInfo.FlatAppearance.BorderSize = 0;
            btnTabFriends.FlatAppearance.BorderSize = 0;

            // Bật cuộn cho vùng thông tin bên dưới để không bị khuất mất
            flpContent.AutoScroll = true;
            flpContent.WrapContents = false;
            flpContent.FlowDirection = FlowDirection.TopDown;
            flpContent.BackColor = Color.White;

            flpFriends.AutoScroll = true;
            flpFriends.WrapContents = false;
            flpFriends.FlowDirection = FlowDirection.TopDown;

            pnlIndicator.BackColor = blue;

            flpContent.Resize += (s, e) => ResizeInfoCards();

            ChangeAvatar.BringToFront();
            EditProfile.BringToFront();
            btnTabInfo.BringToFront();
            btnTabFriends.BringToFront();
        }

        // =========================
        // BO GÓC
        // =========================

        private void ApplyRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(control.Width - d, 0, d, d, 270, 90);
                path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
                path.AddArc(0, control.Height - d, d, d, 90, 90);
                path.CloseFigure();

                Region oldRegion = control.Region;
                control.Region = new Region(path);

                if (oldRegion != null)
                    oldRegion.Dispose();
            }
        }

        private void SetRounded(Control control, int radius)
        {
            ApplyRoundedRegion(control, radius);
            control.Resize += (s, e) => ApplyRoundedRegion(control, radius);
        }

        private void MakeAvatarCircle()
        {
            if (Avatar.Width <= 0 || Avatar.Height <= 0)
                return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, Avatar.Width, Avatar.Height);

                Region oldRegion = Avatar.Region;
                Avatar.Region = new Region(path);

                if (oldRegion != null)
                    oldRegion.Dispose();
            }
        }

        private void CenterCard()
        {
            if (Card == null)
                return;

            Card.Left = Math.Max(
                0, (ClientSize.Width - Card.Width) / 2);

            Card.Top = Math.Max(
                0, (ClientSize.Height - Card.Height) / 2);
        }

        // =========================
        // ICON
        // =========================

        private void DrawInfoIcon(
            object sender, PaintEventArgs e, string type)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen p = new Pen(blue, 2.2f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;

                if (type == "email")
                {
                    g.DrawRectangle(p, 13, 17, 28, 21);
                    g.DrawLine(p, 13, 17, 27, 29);
                    g.DrawLine(p, 41, 17, 27, 29);
                }
                else if (type == "uid")
                {
                    g.DrawRectangle(p, 12, 12, 30, 32);
                    g.DrawEllipse(p, 17, 18, 9, 9);
                    g.DrawArc(p, 15, 28, 14, 10, 180, 180);
                    g.DrawLine(p, 31, 21, 37, 21);
                    g.DrawLine(p, 31, 27, 37, 27);
                    g.DrawLine(p, 31, 33, 37, 33);
                }
                else if (type == "name")
                {
                    g.DrawEllipse(p, 20, 10, 14, 14);
                    g.DrawArc(p, 12, 25, 30, 25, 180, 180);
                }
                else if (type == "account")
                {
                    using (Font f = new Font(
                        "Segoe UI", 23, FontStyle.Bold))
                    {
                        TextRenderer.DrawText(
                            g, "@", f,
                            new Rectangle(0, 0, 54, 54),
                            blue,
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.VerticalCenter);
                    }
                }
            }
        }

        // =========================
        // TẠO THẺ THÔNG TIN
        // =========================

        private Panel CreateInfoCard(
            string icon, string title, string value)
        {
            Panel card = new Panel();

            int scrollReserve = flpContent.VerticalScroll.Visible ? 20 : 0;
            card.Width = Math.Max(100, flpContent.ClientSize.Width - 20 - scrollReserve);
            card.Height = 92;
            card.Margin = new Padding(3, 4, 3, 4);
            card.BackColor = lightBlue;

            Panel iconPanel = new Panel();
            iconPanel.Size = new Size(54, 54);
            iconPanel.Location = new Point(18, 19);
            iconPanel.BackColor = Color.FromArgb(226, 237, 255);

            SetRounded(iconPanel, 14);

            iconPanel.Paint += (s, e) =>
                DrawInfoIcon(s, e, icon);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = dark;
            lblTitle.Location = new Point(88, 14);
            lblTitle.Size = new Size(card.Width - 110, 27);

            Label lblValue = new Label();
            lblValue.Text = string.IsNullOrWhiteSpace(value)
                ? "Chưa cập nhật"
                : value;

            lblValue.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblValue.ForeColor = muted;
            lblValue.Location = new Point(88, 46);
            lblValue.Size = new Size(card.Width - 110, 28);
            lblValue.AutoEllipsis = true;

            card.Controls.Add(iconPanel);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);

            SetRounded(card, 15);

            return card;
        }

        // =========================
        // KÍCH THƯỚC THẺ
        // =========================

        private void ResizeInfoCards()
        {
            int scrollReserve = flpContent.VerticalScroll.Visible ? 20 : 0;
            int targetWidth = Math.Max(100, flpContent.ClientSize.Width - 20 - scrollReserve);

            foreach (Control card in flpContent.Controls)
            {
                card.Width = targetWidth;
                ApplyRoundedRegion(card, 15);

                foreach (Control child in card.Controls)
                {
                    if (child is Label && child.Left == 88)
                        child.Width = card.Width - 110;
                }
            }
        }

        // =========================
        // HIỂN THỊ THÔNG TIN
        // =========================

        private void LoadInfoCards()
        {
            flpContent.SuspendLayout();

            try
            {
                flpContent.Controls.Clear();

                flpContent.Controls.Add(CreateInfoCard(
                    "email", "Email đăng nhập", currentEmail));

                flpContent.Controls.Add(CreateInfoCard(
                    "uid", "Mã định danh (UID)", currentUID));

                flpContent.Controls.Add(CreateInfoCard(
                    "name", "Tên tài khoản", currentDisplayName));

                flpContent.Controls.Add(CreateInfoCard(
                    "account", "Username đăng nhập", currentUsername));
            }
            finally
            {
                flpContent.ResumeLayout(true);
            }

            ResizeInfoCards();
        }

        // =========================
        // LẤY USER ĐANG ĐĂNG NHẬP
        // =========================

        private async void LoadCurrentUser()
        {
            string email = UserSession.Email ?? SupabaseAuthService.CurrentUserEmail ?? "";
            string uid = UserSession.UserId ?? SupabaseAuthService.CurrentUserId ?? "";
            string displayName = UserSession.DisplayName ?? "";

            string username = "";
            if (!string.IsNullOrWhiteSpace(email))
                username = email.Split('@')[0];

            if (string.IsNullOrWhiteSpace(displayName))
                displayName = username;

            SetLoggedInUser(
                username,
                email,
                uid,
                displayName,
                0,
                0);

            // Đồng bộ dữ liệu mới nhất từ bảng profiles trên Supabase
            try
            {
                JObject profile = await SupabaseAuthService.GetCurrentProfileAsync();
                if (profile != null)
                {
                    string dbUsername = (string)profile["username"] ?? username;
                    string dbDisplayName = (string)profile["display_name"] ?? (string)profile["full_name"] ?? displayName;
                    string dbAvatarUrl = (string)profile["avatar_url"];

                    UserSession.DisplayName = dbDisplayName;
                    if (!string.IsNullOrWhiteSpace(email)) UserSession.Email = email;
                    if (!string.IsNullOrWhiteSpace(uid)) UserSession.UserId = uid;

                    SetLoggedInUser(
                        dbUsername,
                        email,
                        uid,
                        dbDisplayName,
                        GetCurrentPostCount(),
                        GetCurrentFriendCount());

                    if (!string.IsNullOrWhiteSpace(dbAvatarUrl))
                    {
                        Image img = await SupabaseAuthService.DownloadImageAsync(dbAvatarUrl);
                        if (img != null)
                        {
                            using (img)
                            {
                                SetAvatar(img);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Giữ nguyên dữ liệu session cục bộ nếu chưa kết nối được DB
            }
        }

        // =========================
        // CẬP NHẬT USER
        // =========================

        public void SetLoggedInUser(
            string username,
            string email,
            string uid,
            string displayName,
            int postCount,
            int friendCount)
        {
            currentUsername = username ?? "";
            currentEmail = email ?? "";
            currentUID = uid ?? "";
            currentDisplayName = displayName ?? "";

            string effectiveUsername = !string.IsNullOrWhiteSpace(currentUsername)
                ? currentUsername
                : (!string.IsNullOrWhiteSpace(currentEmail) ? currentEmail.Split('@')[0] : "Người dùng");

            string effectiveAccountName = !string.IsNullOrWhiteSpace(currentDisplayName)
                ? currentDisplayName
                : effectiveUsername;

            // Dòng 1: Username đăng nhập
            lblUsername.Text = effectiveUsername;

            // Dòng 2: Tên tài khoản (cùng font & màu với username nhưng nhỏ hơn, không icon thư, không nền xanh)
            lblAccountName.Text = effectiveAccountName;

            lblPostsCount.Text = postCount + " bài viết";
            lblFriendsCount.Text = friendCount + " bạn bè";

            LoadInfoCards();
        }

        // =========================
        // TƯƠNG THÍCH CODE CŨ
        // =========================

        public void SetProfileInfo(
            string username, string email,
            int postCount, int friendCount)
        {
            SetLoggedInUser(
                username,
                email,
                "UID_" + email,
                username,
                postCount,
                friendCount);
        }

        // =========================
        // AVATAR
        // =========================

        public void SetAvatar(Image image)
        {
            Image newImage = image == null
                ? null
                : (Image)image.Clone();

            Image oldImage = Avatar.Image;
            Avatar.Image = newImage;

            if (oldImage != null)
                oldImage.Dispose();

            MakeAvatarCircle();
        }

        // =========================
        // TAB THÔNG TIN
        // =========================

        private void ShowInfoTab()
        {
            flpContent.Visible = true;
            flpFriends.Visible = false;

            pnlIndicator.Left = btnTabInfo.Left;
            pnlIndicator.Width = btnTabInfo.Width;

            btnTabInfo.ForeColor = blue;
            btnTabFriends.ForeColor = muted;

            pnlIndicator.BringToFront();
            ResizeInfoCards();
        }

        private void btnTabInfo_Click(object sender, EventArgs e)
        {
            ShowInfoTab();
        }

        // =========================
        // TAB BẠN BÈ
        // =========================

        private void ShowFriendsTab()
        {
            flpContent.Visible = false;
            flpFriends.Visible = true;

            pnlIndicator.Left = btnTabFriends.Left;
            pnlIndicator.Width = btnTabFriends.Width;

            btnTabFriends.ForeColor = blue;
            btnTabInfo.ForeColor = muted;

            pnlIndicator.BringToFront();
        }

        private void btnTabFriends_Click(object sender, EventArgs e)
        {
            ShowFriendsTab();
        }

        private void BindEvents()
        {
            ChangeAvatar.Click += ChangeAvatar_Click;
            EditProfile.Click += EditProfile_Click;
            btnTabInfo.Click += btnTabInfo_Click;
            btnTabFriends.Click += btnTabFriends_Click;
        }

        // =========================
        // 1. ĐỔI ẢNH ĐẠI DIỆN
        // =========================

        private async void ChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.webp)|*.jpg;*.jpeg;*.png;*.webp";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                FileInfo info = new FileInfo(ofd.FileName);
                if (info.Length > 5 * 1024 * 1024)
                {
                    MessageBox.Show("Ảnh đại diện không được vượt quá 5MB.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị ngay ảnh vừa chọn lên giao diện
                using (Image temp = Image.FromFile(ofd.FileName))
                {
                    SetAvatar(temp);
                }

                ChangeAvatar.Enabled = false;
                string oldText = ChangeAvatar.Text;
                ChangeAvatar.Text = "Đang tải lên...";
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    await SupabaseAuthService.UploadAvatarAsync(ofd.FileName);
                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã hiển thị ảnh tạm thời nhưng chưa lưu được lên máy chủ:\n" + ex.Message,
                        "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    ChangeAvatar.Enabled = true;
                    ChangeAvatar.Text = oldText;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        // =========================
        // 2. CHỈNH SỬA THÔNG TIN CÁ NHÂN
        // =========================

        private async void EditProfile_Click(object sender, EventArgs e)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "Chỉnh sửa trang cá nhân";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ClientSize = new Size(420, 270);
                dlg.BackColor = Color.White;
                dlg.Font = new Font("Segoe UI", 10);

                Label lblTitle = new Label
                {
                    Text = "Chỉnh sửa thông tin cá nhân",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = dark,
                    Location = new Point(24, 18),
                    AutoSize = true
                };

                Label lblUser = new Label
                {
                    Text = "Username đăng nhập (ID riêng)",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = dark,
                    Location = new Point(24, 62),
                    AutoSize = true
                };

                TextBox txtUsername = new TextBox
                {
                    Text = currentUsername,
                    Location = new Point(24, 86),
                    Width = 370,
                    Font = new Font("Segoe UI", 11)
                };

                Label lblName = new Label
                {
                    Text = "Tên tài khoản (Tên hiển thị)",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = dark,
                    Location = new Point(24, 130),
                    AutoSize = true
                };

                TextBox txtDisplayName = new TextBox
                {
                    Text = currentDisplayName,
                    Location = new Point(24, 154),
                    Width = 370,
                    Font = new Font("Segoe UI", 11)
                };

                Button btnCancel = new Button
                {
                    Text = "Hủy",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(204, 208),
                    Size = new Size(88, 36),
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = dark,
                    FlatStyle = FlatStyle.Flat
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                Button btnSave = new Button
                {
                    Text = "Lưu thay đổi",
                    Location = new Point(300, 208),
                    Size = new Size(94, 36),
                    BackColor = blue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnSave.FlatAppearance.BorderSize = 0;

                btnSave.Click += async (s, args) =>
                {
                    string newUser = txtUsername.Text.Trim();
                    string newName = txtDisplayName.Text.Trim();

                    if (newUser.Length < 3 || newUser.Contains("@") || newUser.Contains(" "))
                    {
                        MessageBox.Show("Username phải từ 3 ký tự trở lên, không chứa dấu cách hoặc ký tự @.",
                            "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        MessageBox.Show("Vui lòng nhập tên tài khoản.",
                            "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDisplayName.Focus();
                        return;
                    }

                    btnSave.Enabled = false;
                    btnSave.Text = "Đang lưu...";
                    dlg.Cursor = Cursors.WaitCursor;

                    try
                    {
                        // Nếu đổi username mới thì kiểm tra xem đã có ai dùng chưa
                        if (!string.Equals(newUser, currentUsername, StringComparison.OrdinalIgnoreCase))
                        {
                            bool exists = await SupabaseAuthService.AccountExistsAsync(newUser);
                            if (exists)
                            {
                                MessageBox.Show("Username này đã có người sử dụng, vui lòng chọn tên khác.",
                                    "Trùng Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtUsername.Focus();
                                return;
                            }
                        }

                        await SupabaseAuthService.UpdateProfileAsync(newUser, newName);

                        UserSession.DisplayName = newName;
                        SetLoggedInUser(
                            newUser,
                            currentEmail,
                            currentUID,
                            newName,
                            GetCurrentPostCount(),
                            GetCurrentFriendCount());

                        dlg.DialogResult = DialogResult.OK;
                        dlg.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể cập nhật thông tin:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (!dlg.IsDisposed)
                        {
                            btnSave.Enabled = true;
                            btnSave.Text = "Lưu thay đổi";
                            dlg.Cursor = Cursors.Default;
                        }
                    }
                };

                dlg.Controls.AddRange(new Control[]
                {
                    lblTitle, lblUser, txtUsername, lblName, txtDisplayName, btnCancel, btnSave
                });
                dlg.AcceptButton = btnSave;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Đã cập nhật thông tin trang cá nhân!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int GetCurrentPostCount()
        {
            var parts = lblPostsCount.Text.Split(' ');
            return int.TryParse(parts[0], out int c) ? c : 0;
        }

        private int GetCurrentFriendCount()
        {
            var parts = lblFriendsCount.Text.Split(' ');
            return int.TryParse(parts[0], out int c) ? c : 0;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(
                Color.FromArgb(240, 243, 248), 1))
            {
                Rectangle rect = new Rectangle(
                    0, 0, Card.Width - 1, Card.Height - 1);

                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 26;
                    int d = r * 2;

                    path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(rect.Right - d, rect.Bottom - d,
                        d, d, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - d,
                        d, d, 90, 90);

                    path.CloseFigure();
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}