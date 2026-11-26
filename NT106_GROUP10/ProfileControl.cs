using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
        private string currentBio = "";
        private string currentGender = "Không muốn tiết lộ";

        private EditProfileControl editControl;

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

        private void BindEvents()
        {
            EditProfile.Click += EditProfile_Click;
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

            lblUsername.ForeColor = dark;
            lblUsername.Font = new Font("Segoe UI", 25, FontStyle.Bold);

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

            flpContent.AutoScroll = true;
            flpContent.WrapContents = false;
            flpContent.FlowDirection = FlowDirection.TopDown;
            flpContent.BackColor = Color.White;

            flpFriends.AutoScroll = true;
            flpFriends.WrapContents = false;
            flpFriends.FlowDirection = FlowDirection.TopDown;

            pnlIndicator.BackColor = blue;

            flpContent.Resize += (s, e) => ResizeInfoCards();
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

            Card.Left = Math.Max(0, (ClientSize.Width - Card.Width) / 2);
            Card.Top = Math.Max(0, (ClientSize.Height - Card.Height) / 2);
        }

        // =========================
        // ICON
        // =========================

        private void DrawInfoIcon(object sender, PaintEventArgs e, string type)
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
                    using (Font f = new Font("Segoe UI", 23, FontStyle.Bold))
                    {
                        TextRenderer.DrawText(
                            g, "@", f,
                            new Rectangle(0, 0, 54, 54),
                            blue,
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.VerticalCenter);
                    }
                }
                else
                {
                    g.DrawEllipse(p, 18, 15, 18, 18);
                    g.DrawLine(p, 27, 35, 27, 42);
                }
            }
        }

        // =========================
        // TẠO THẺ THÔNG TIN
        // =========================

        private Panel CreateInfoCard(string icon, string title, string value)
        {
            Panel card = new Panel();
            card.Width = Math.Max(100, flpContent.ClientSize.Width - 20);
            card.Height = 92;
            card.Margin = new Padding(3, 4, 3, 4);
            card.BackColor = lightBlue;

            Panel iconPanel = new Panel();
            iconPanel.Size = new Size(54, 54);
            iconPanel.Location = new Point(18, 19);
            iconPanel.BackColor = Color.FromArgb(226, 237, 255);
            SetRounded(iconPanel, 14);
            iconPanel.Paint += (s, e) => DrawInfoIcon(s, e, icon);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = dark;
            lblTitle.Location = new Point(88, 14);
            lblTitle.Size = new Size(card.Width - 110, 27);

            Label lblValue = new Label();
            lblValue.Text = string.IsNullOrWhiteSpace(value) ? "Chưa cập nhật" : value;
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

        private void ResizeInfoCards()
        {
            foreach (Control card in flpContent.Controls)
            {
                card.Width = Math.Max(100, flpContent.ClientSize.Width - 20);
                foreach (Control child in card.Controls)
                {
                    if (child is Label && child.Left == 88)
                        child.Width = card.Width - 110;
                }
            }
        }

        private void LoadInfoCards()
        {
            flpContent.SuspendLayout();
            try
            {
                flpContent.Controls.Clear();
                flpContent.Controls.Add(CreateInfoCard("email", "Email đăng nhập", currentEmail));
                flpContent.Controls.Add(CreateInfoCard("uid", "Mã định danh (UID)", currentUID));
                flpContent.Controls.Add(CreateInfoCard("name", "Tên hiển thị", currentDisplayName));
                flpContent.Controls.Add(CreateInfoCard("account", "Tên tài khoản", currentUsername));
                flpContent.Controls.Add(CreateInfoCard("bio", "Tiểu sử", currentBio));
                flpContent.Controls.Add(CreateInfoCard("gender", "Giới tính", currentGender));
            }
            finally
            {
                flpContent.ResumeLayout(true);
            }

            ResizeInfoCards();
        }

        // =========================
        // USER & CẬP NHẬT
        // =========================

        private void LoadCurrentUser()
        {
            string email = UserSession.Email ?? "";
            string uid = UserSession.UserId ?? "";
            string displayName = UserSession.DisplayName ?? "";

            string username = "";
            if (!string.IsNullOrWhiteSpace(email))
                username = email.Split('@')[0];

            if (string.IsNullOrWhiteSpace(displayName))
                displayName = username;

            SetLoggedInUser(username, email, uid, displayName, 0, 0, currentBio, currentGender);
        }

        public void SetLoggedInUser(
            string username,
            string email,
            string uid,
            string displayName,
            int postCount,
            int friendCount,
            string bio = null,
            string gender = null)
        {
            currentUsername = username ?? "";
            currentEmail = email ?? "";
            currentUID = uid ?? "";
            currentDisplayName = displayName ?? "";
            if (bio != null) currentBio = bio;
            if (!string.IsNullOrWhiteSpace(gender)) currentGender = gender;

            lblUsername.Text = string.IsNullOrWhiteSpace(currentDisplayName)
                ? currentUsername
                : currentDisplayName;

            if (string.IsNullOrWhiteSpace(lblUsername.Text))
                lblUsername.Text = "Người dùng";

            lblAccountName.Text = string.IsNullOrWhiteSpace(currentUsername)
                ? "Chưa cập nhật"
                : currentUsername;

            lblPostsCount.Text = postCount + " bài viết";
            lblFriendsCount.Text = friendCount + " bạn bè";

            LoadInfoCards();
        }

        public void SetProfileInfo(string username, string email, int postCount, int friendCount)
        {
            SetLoggedInUser(username, email, "UID_" + email, username, postCount, friendCount);
        }

        public void SetAvatar(Image image)
        {
            Image newImage = image == null ? null : (Image)image.Clone();
            Image oldImage = Avatar.Image;
            Avatar.Image = newImage;

            if (oldImage != null)
                oldImage.Dispose();

            MakeAvatarCircle();
        }

        private void ChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image temp = Image.FromFile(ofd.FileName))
                        {
                            SetAvatar(temp);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            if (editControl == null)
            {
                editControl = new EditProfileControl();
                editControl.Dock = DockStyle.Fill;

                editControl.Cancelled += () => editControl.Visible = false;

                editControl.ProfileUpdated += (newUser, newName, newBio, newGender) =>
                {
                    editControl.Visible = false;

                    SetLoggedInUser(
                        newUser,
                        currentEmail,
                        currentUID,
                        newName,
                        GetCurrentPostCount(),
                        GetCurrentFriendCount(),
                        newBio,
                        newGender);
                };

                Card.Controls.Add(editControl);
            }

            editControl.LoadData(currentUsername, currentDisplayName, currentBio, currentGender);
            editControl.Visible = true;
            editControl.BringToFront();
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

        // =========================
        // TAB
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
        }

        private void btnTabInfo_Click(object sender, EventArgs e)
        {
            ShowInfoTab();
        }

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

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(240, 243, 248), 1))
            {
                Rectangle rect = new Rectangle(0, 0, Card.Width - 1, Card.Height - 1);

                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 26;
                    int d = r * 2;

                    path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

                    path.CloseFigure();
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}