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
        private string currentAvatarUrl = "";

        private int currentPostCount = 0;
        private int currentFriendCount = 0;

        public ProfileControl()
        {
            InitializeComponent();

            SetupDesign();

            this.Resize += (s, e) => CenterCard();
            CenterCard();

            ChangeAvatar.Click += ChangeAvatar_Click;
            EditProfile.Click += EditProfile_Click;

            LoadCurrentUser();
            ShowInfoTab();
        }

        private void SetupDesign()
        {
            BackColor = Color.FromArgb(244, 247, 252);

            Card.BackColor = Color.White;
            SetRounded(Card, 24);

            Avatar.SizeMode = PictureBoxSizeMode.Zoom;
            Avatar.BackColor = Color.FromArgb(226, 232, 240);
            MakeAvatarCircle();
            Avatar.Resize += (s, e) => MakeAvatarCircle();

            lblUsername.ForeColor = dark;
            lblUsername.Font = new Font("Segoe UI", 25, FontStyle.Bold);

            lblAccountName.BackColor = Color.White;
            lblAccountName.ForeColor = dark;
            lblAccountName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblAccountName.Padding = new Padding(0);
            lblAccountName.AutoEllipsis = true;

            lblPostsCount.ForeColor = blue;
            lblFriendsCount.ForeColor = dark;

            ChangeAvatar.BackColor = blue;
            ChangeAvatar.ForeColor = Color.White;
            ChangeAvatar.FlatStyle = FlatStyle.Flat;
            ChangeAvatar.FlatAppearance.BorderSize = 0;
            ChangeAvatar.Cursor = Cursors.Hand;
            SetRounded(ChangeAvatar, 12);

            EditProfile.BackColor = Color.FromArgb(235, 243, 255);
            EditProfile.ForeColor = blue;
            EditProfile.FlatStyle = FlatStyle.Flat;
            EditProfile.FlatAppearance.BorderSize = 0;
            EditProfile.Cursor = Cursors.Hand;
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

        private void SetRounded(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            ApplyRoundedRegion(control, radius);

            control.Resize -= RoundedControl_Resize;
            control.Resize += RoundedControl_Resize;
        }

        private void RoundedControl_Resize(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            int radius = control == Card ? 24 :
                control == ChangeAvatar || control == EditProfile ? 12 : 14;

            ApplyRoundedRegion(control, radius);
        }

        private void ApplyRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = Math.Min(radius * 2,
                    Math.Min(control.Width, control.Height));

                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(control.Width - d, 0, d, d, 270, 90);
                path.AddArc(control.Width - d,
                    control.Height - d, d, d, 0, 90);
                path.AddArc(0, control.Height - d, d, d, 90, 90);
                path.CloseFigure();

                Region oldRegion = control.Region;
                control.Region = new Region(path);

                if (oldRegion != null)
                    oldRegion.Dispose();
            }
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
            if (Card == null) return;

            Card.Left = Math.Max(0,
                (ClientSize.Width - Card.Width) / 2);

            Card.Top = Math.Max(0,
                (ClientSize.Height - Card.Height) / 2);
        }

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

        private Panel CreateInfoCard(
            string icon, string title, string value)
        {
            Panel card = new Panel();
            card.Width = Math.Max(
                100, flpContent.ClientSize.Width - 20);
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
            lblTitle.Font = new Font(
                "Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = dark;
            lblTitle.Location = new Point(88, 14);
            lblTitle.Size = new Size(card.Width - 110, 27);

            Label lblValue = new Label();
            lblValue.Text = string.IsNullOrWhiteSpace(value)
                ? "Chưa cập nhật" : value;
            lblValue.Font = new Font("Segoe UI", 10);
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
                card.Width = Math.Max(
                    100, flpContent.ClientSize.Width - 25);

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

                flpContent.Controls.Add(
                    CreateInfoCard(
                        "email", "Email đăng nhập", currentEmail));

                flpContent.Controls.Add(
                    CreateInfoCard(
                        "uid", "Mã định danh (UID)", currentUID));

                flpContent.Controls.Add(
                    CreateInfoCard(
                        "name", "Tên hiển thị", currentDisplayName));

                flpContent.Controls.Add(
                    CreateInfoCard(
                        "account", "Tên tài khoản", currentUsername));
            }
            finally
            {
                flpContent.ResumeLayout(true);
            }

            ResizeInfoCards();

            // Luôn cuộn về đầu để thấy thẻ Email.
            flpContent.AutoScrollPosition = new Point(0, 0);
        }

        // Email và UID luôn lấy từ Supabase Auth, bỏ qua giá trị
        // do form cha truyền vào (có thể là dữ liệu giả).
        private void SyncAuthInfo()
        {
            if (!string.IsNullOrWhiteSpace(
                SupabaseAuthService.CurrentUserId))
                currentUID = SupabaseAuthService.CurrentUserId;

            if (!string.IsNullOrWhiteSpace(
                SupabaseAuthService.CurrentUserEmail))
                currentEmail = SupabaseAuthService.CurrentUserEmail;
        }

        private async void LoadCurrentUser()
        {
            try
            {
                SyncAuthInfo();

                JObject profile =
                    await SupabaseAuthService.GetCurrentProfileAsync();

                currentUsername = (string)profile["username"] ?? "";
                currentDisplayName =
                    (string)profile["display_name"] ?? "";
                currentAvatarUrl = (string)profile["avatar_url"] ?? "";

                SyncAuthInfo();

                if (string.IsNullOrWhiteSpace(currentUsername))
                {
                    currentUsername = !string.IsNullOrWhiteSpace(currentEmail)
                        ? currentEmail.Split('@')[0]
                        : "Người dùng";
                }

                if (string.IsNullOrWhiteSpace(currentDisplayName))
                    currentDisplayName = currentUsername;

                UpdateHeader(currentPostCount, currentFriendCount);
                LoadInfoCards();

                if (!string.IsNullOrWhiteSpace(currentAvatarUrl))
                    await LoadAvatarFromUrlAsync(currentAvatarUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin hồ sơ.\n\n" + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async Task LoadAvatarFromUrlAsync(string url)
        {
            try
            {
                using (System.Net.Http.HttpClient client =
                    new System.Net.Http.HttpClient())
                {
                    byte[] bytes = await client.GetByteArrayAsync(url);

                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image image = Image.FromStream(ms))
                    {
                        SetAvatar(image);
                    }
                }
            }
            catch
            {
                // Nếu ảnh chưa tải được, giữ ảnh mặc định.
            }
        }

        public void SetLoggedInUser(
            string username, string email, string uid,
            string displayName, int postCount, int friendCount)
        {
            if (!string.IsNullOrWhiteSpace(username))
                currentUsername = username;

            if (!string.IsNullOrWhiteSpace(displayName))
                currentDisplayName = displayName;

            // Tham số email, uid chỉ dùng khi chưa có dữ liệu từ Auth.
            if (string.IsNullOrWhiteSpace(currentEmail))
                currentEmail = email ?? "";

            if (string.IsNullOrWhiteSpace(currentUID))
                currentUID = uid ?? "";

            SyncAuthInfo();

            currentPostCount = postCount;
            currentFriendCount = friendCount;

            UpdateHeader(postCount, friendCount);
            LoadInfoCards();
        }

        private void UpdateHeader(int postCount, int friendCount)
        {
            lblUsername.Text =
                string.IsNullOrWhiteSpace(currentUsername)
                ? "Người dùng" : currentUsername;

            lblAccountName.Text =
                string.IsNullOrWhiteSpace(currentDisplayName)
                ? currentUsername : currentDisplayName;

            lblPostsCount.Text = postCount + " bài viết";
            lblFriendsCount.Text = friendCount + " bạn bè";
        }

        public void SetProfileInfo(
            string username, string email,
            int postCount, int friendCount)
        {
            SetLoggedInUser(
                username, email, currentUID,
                currentDisplayName, postCount, friendCount);
        }

        public void SetAvatar(Image image)
        {
            Image newImage = image == null
                ? null : (Image)image.Clone();

            Image oldImage = Avatar.Image;
            Avatar.Image = newImage;

            if (oldImage != null)
                oldImage.Dispose();

            MakeAvatarCircle();
        }

        private async void ChangeAvatar_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                SupabaseAuthService.CurrentUserId))
            {
                MessageBox.Show(
                    "Không xác định được tài khoản. Vui lòng đăng nhập lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh đại diện";
                dialog.Filter =
                    "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ChangeAvatar.Enabled = false;
                    ChangeAvatar.Text = "Đang tải ảnh...";

                    string extension =
                        Path.GetExtension(dialog.FileName).ToLowerInvariant();

                    string contentType;

                    switch (extension)
                    {
                        case ".png":
                            contentType = "image/png";
                            break;
                        case ".bmp":
                            contentType = "image/bmp";
                            break;
                        default:
                            contentType = "image/jpeg";
                            break;
                    }

                    byte[] imageBytes =
                        File.ReadAllBytes(dialog.FileName);

                    if (imageBytes.Length > 5 * 1024 * 1024)
                    {
                        throw new Exception(
                            "Ảnh không được lớn hơn 5 MB.");
                    }

                    string newAvatarUrl =
                        await SupabaseAuthService.UploadAvatarAsync(
                            imageBytes, extension, contentType);

                    using (MemoryStream ms =
                        new MemoryStream(imageBytes))
                    using (Image selectedImage =
                        Image.FromStream(ms))
                    {
                        SetAvatar(selectedImage);
                    }

                    currentAvatarUrl = newAvatarUrl;

                    MessageBox.Show(
                        "Đã cập nhật ảnh đại diện thành công.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể đổi ảnh đại diện.\n\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    ChangeAvatar.Enabled = true;
                    ChangeAvatar.Text = "Đổi ảnh đại diện";
                }
            }
        }

        private async void EditProfile_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                SupabaseAuthService.CurrentUserId))
            {
                MessageBox.Show(
                    "Không xác định được tài khoản. Vui lòng đăng nhập lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (EditProfileDialog dialog =
                new EditProfileDialog(currentDisplayName))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                    return;

                string newDisplayName =
                    dialog.DisplayNameValue.Trim();

                if (string.IsNullOrWhiteSpace(newDisplayName))
                {
                    MessageBox.Show(
                        "Tên hiển thị không được để trống.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    EditProfile.Enabled = false;

                    await SupabaseAuthService.UpdateDisplayNameAsync(
                        newDisplayName);

                    currentDisplayName = newDisplayName;

                    UpdateHeader(
                        currentPostCount, currentFriendCount);

                    LoadInfoCards();

                    MessageBox.Show(
                        "Đã cập nhật thông tin cá nhân.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể cập nhật thông tin.\n\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    EditProfile.Enabled = true;
                }
            }
        }

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
                    path.AddArc(
                        rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(
                        rect.Right - d, rect.Bottom - d,
                        d, d, 0, 90);
                    path.AddArc(
                        rect.X, rect.Bottom - d, d, d, 90, 90);

                    path.CloseFigure();
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }

    internal class EditProfileDialog : Form
    {
        private TextBox txtDisplayName;

        public string DisplayNameValue
        {
            get { return txtDisplayName.Text; }
        }

        public EditProfileDialog(string currentName)
        {
            Text = "Chỉnh sửa thông tin cá nhân";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(440, 205);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10);

            Label title = new Label();
            title.Text = "Tên hiển thị";
            title.Font = new Font(
                "Segoe UI", 10, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(35, 51, 75);
            title.Location = new Point(25, 25);
            title.Size = new Size(380, 25);

            txtDisplayName = new TextBox();
            txtDisplayName.Text = currentName ?? "";
            txtDisplayName.Font = new Font("Segoe UI", 11);
            txtDisplayName.Location = new Point(25, 58);
            txtDisplayName.Size = new Size(390, 32);
            txtDisplayName.MaxLength = 100;

            Button btnSave = new Button();
            btnSave.Text = "Lưu thay đổi";
            btnSave.DialogResult = DialogResult.OK;
            btnSave.BackColor = Color.FromArgb(48, 116, 235);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(220, 130);
            btnSave.Size = new Size(125, 40);

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.BackColor = Color.FromArgb(235, 243, 255);
            btnCancel.ForeColor = Color.FromArgb(48, 116, 235);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Location = new Point(355, 130);
            btnCancel.Size = new Size(60, 40);

            Controls.Add(title);
            Controls.Add(txtDisplayName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }
    }
}
