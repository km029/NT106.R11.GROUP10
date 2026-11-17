
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public partial class HomePage : UserControl
    {
        private Color blue = Color.FromArgb(0, 149, 246);
        private Color background = Color.FromArgb(250, 250, 250);

        private FlowLayoutPanel storyFlow;
        private FlowLayoutPanel feedFlow;
        private FlowLayoutPanel suggestionFlow;
        private Panel feedHost;
        private Panel rightPanel;

        private string currentUser = "my_username";

        public HomePage()
        {
            InitializeComponent();

            Controls.Clear();

            BackColor = background;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;

            CreateInterface();
        }

        // ==========================================
        // GIAO DIEN CHINH
        // ==========================================

        private void CreateInterface()
        {
            TableLayoutPanel main = new TableLayoutPanel();
            main.Dock = DockStyle.Fill;
            main.BackColor = background;
            main.ColumnCount = 2;
            main.RowCount = 1;
            main.Padding = new Padding(20, 15, 20, 15);

            main.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 72));

            main.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 28));

            Controls.Add(main);

            // Cot ben trai
            Panel leftPanel = new Panel();
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.BackColor = background;

            main.Controls.Add(leftPanel, 0, 0);

            // Tieu de
            Label title = new Label();
            title.Text = "Bảng tin";
            title.Font = new Font("Arial", 21, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(35, 35, 35);
            title.Location = new Point(15, 5);
            title.AutoSize = true;

            leftPanel.Controls.Add(title);

            // ======================================
            // STORIES
            // ======================================

            Label storyTitle = new Label();
            storyTitle.Text = "Stories";
            storyTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            storyTitle.ForeColor = Color.FromArgb(45, 45, 45);
            storyTitle.Location = new Point(17, 53);
            storyTitle.AutoSize = true;

            leftPanel.Controls.Add(storyTitle);

            storyFlow = new FlowLayoutPanel();
            storyFlow.Location = new Point(10, 82);
            storyFlow.Size = new Size(750, 140);
            storyFlow.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            storyFlow.AutoScroll = true;
            storyFlow.WrapContents = false;
            storyFlow.FlowDirection = FlowDirection.LeftToRight;
            storyFlow.BackColor = background;
            storyFlow.Padding = new Padding(3);

            leftPanel.Controls.Add(storyFlow);

            CreateStories();

            // ======================================
            // BANG TIN
            // ======================================

            feedHost = new Panel();
            feedHost.Location = new Point(10, 230);
            feedHost.Size = new Size(750, 600);
            feedHost.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            feedHost.AutoScroll = true;
            feedHost.BackColor = background;

            leftPanel.Controls.Add(feedHost);

            feedFlow = new FlowLayoutPanel();
            feedFlow.Location = new Point(5, 5);
            feedFlow.AutoSize = true;
            feedFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            feedFlow.FlowDirection = FlowDirection.TopDown;
            feedFlow.WrapContents = false;
            feedFlow.BackColor = background;

            feedHost.Controls.Add(feedFlow);

            CreatePosts();

            // ======================================
            // COT BEN PHAI
            // ======================================

            rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = background;
            rightPanel.AutoScroll = true;
            rightPanel.Padding = new Padding(15, 5, 5, 5);

            main.Controls.Add(rightPanel, 1, 0);

            CreateRightPanel();

            // Tu dong thay doi kich thuoc bai dang
            feedHost.Resize += (s, e) =>
            {
                UpdatePostWidths();
            };

            leftPanel.Resize += (s, e) =>
            {
                storyFlow.Width = leftPanel.ClientSize.Width - 20;
                feedHost.Width = leftPanel.ClientSize.Width - 20;
            };

            UpdatePostWidths();
        }

        // ==========================================
        // STORIES
        // ==========================================

        private void CreateStories()
        {
            AddStory("+", "Your story", Color.FromArgb(0, 149, 246), true);

            AddStory("N", "ngocanh", Color.FromArgb(185, 115, 210));
            AddStory("M", "minhthu", Color.FromArgb(92, 185, 140));
            AddStory("H", "hoangnam", Color.FromArgb(92, 185, 140));
            AddStory("T", "thanhdat", Color.FromArgb(245, 170, 90));
            AddStory("L", "linhchi", Color.FromArgb(85, 150, 225));
            AddStory("Q", "quanghuy", Color.FromArgb(85, 150, 225));
            AddStory("P", "phuong", Color.FromArgb(240, 100, 120));
            AddStory("T", "thanhngan", Color.FromArgb(0, 149, 246));
            AddStory("A", "tuananh", Color.FromArgb(185, 115, 210));
        }

        private void AddStory(
            string letter,
            string username,
            Color color,
            bool isOwn = false)
        {
            Panel item = new Panel();
            item.Size = new Size(85, 120);
            item.BackColor = background;
            item.Margin = new Padding(3, 3, 3, 3);
            item.Cursor = Cursors.Hand;

            StoryAvatar avatar = new StoryAvatar();
            avatar.Size = new Size(70, 70);
            avatar.Location = new Point(7, 2);
            avatar.Letter = letter;
            avatar.AvatarColor = color;
            avatar.IsOwn = isOwn;

            Label name = new Label();
            name.Text = username;
            name.Font = new Font("Arial", 9);
            name.ForeColor = Color.FromArgb(35, 35, 35);
            name.TextAlign = ContentAlignment.MiddleCenter;
            name.Size = new Size(85, 25);
            name.Location = new Point(0, 80);

            item.Controls.Add(avatar);
            item.Controls.Add(name);

            EventHandler openStory = (s, e) =>
            {
                MessageBox.Show(
                    isOwn
                    ? "Bạn có thể thêm Story mới tại đây!"
                    : "Đang xem Story của " + username,
                    "Stories",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            item.Click += openStory;
            avatar.Click += openStory;
            name.Click += openStory;

            avatar.MouseEnter += (s, e) =>
            {
                avatar.Size = new Size(74, 74);
                avatar.Location = new Point(5, 0);
            };

            avatar.MouseLeave += (s, e) =>
            {
                avatar.Size = new Size(70, 70);
                avatar.Location = new Point(7, 2);
            };

            storyFlow.Controls.Add(item);
        }

        // ==========================================
        // DANH SACH BAI DANG
        // ==========================================

        private void CreatePosts()
        {
            AddPost(
                "ngocanh",
                "N",
                Color.FromArgb(185, 115, 210),
                "Một ngày thật tuyệt vời cùng bạn bè ♡",
                "SUNSET",
                1250,
                0);

            AddPost(
                "minhthu",
                "M",
                Color.FromArgb(92, 185, 140),
                "Cùng tận hưởng những khoảnh khắc đẹp nhất!",
                "SUMMER",
                856,
                1);

            AddPost(
                "hoangnam",
                "H",
                Color.FromArgb(92, 185, 140),
                "Cuộc sống là những chuyến đi.",
                "TRAVEL",
                623,
                2);

            AddPost(
                "thanhdat",
                "T",
                Color.FromArgb(245, 170, 90),
                "Một ngày mới đầy năng lượng!",
                "GOOD DAY",
                432,
                3);
        }

        private void AddPost(
            string username,
            string letter,
            Color avatarColor,
            string caption,
            string imageTitle,
            int likes,
            int imageStyle)
        {
            Panel card = new Panel();
            card.Width = 650;
            card.Height = 630;
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 5, 0, 20);
            card.BorderStyle = BorderStyle.FixedSingle;

            // Header bai dang
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 65;
            header.BackColor = Color.White;

            StoryAvatar avatar = new StoryAvatar();
            avatar.Size = new Size(43, 43);
            avatar.Location = new Point(13, 10);
            avatar.Letter = letter;
            avatar.AvatarColor = avatarColor;

            Label name = new Label();
            name.Text = username;
            name.Font = new Font("Arial", 10, FontStyle.Bold);
            name.Location = new Point(67, 22);
            name.AutoSize = true;

            Label more = new Label();
            more.Text = "•••";
            more.Font = new Font("Arial", 17, FontStyle.Bold);
            more.Size = new Size(45, 40);
            more.Location = new Point(card.Width - 65, 12);
            more.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            more.TextAlign = ContentAlignment.MiddleCenter;
            more.Cursor = Cursors.Hand;

            header.Controls.Add(avatar);
            header.Controls.Add(name);
            header.Controls.Add(more);

            // Anh minh hoa
            SceneImage scene = new SceneImage();
            scene.Dock = DockStyle.Top;
            scene.Height = 380;
            scene.ImageTitle = imageTitle;
            scene.StyleIndex = imageStyle;
            scene.Cursor = Cursors.Hand;

            // Thanh thao tac
            Panel actions = new Panel();
            actions.Dock = DockStyle.Top;
            actions.Height = 48;
            actions.BackColor = Color.White;

            Label likeButton = CreateAction("♡", 17, 10);
            Label commentButton = CreateAction("○", 65, 10);
            Label shareButton = CreateAction("➤", 115, 10);
            Label saveButton = CreateAction("♧", card.Width - 50, 10);

            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            likeButton.ForeColor = Color.Black;
            likeButton.Font = new Font("Arial", 24);
            likeButton.Cursor = Cursors.Hand;

            actions.Controls.Add(likeButton);
            actions.Controls.Add(commentButton);
            actions.Controls.Add(shareButton);
            actions.Controls.Add(saveButton);

            // Luot thich
            Label likeCount = new Label();
            likeCount.Text = likes.ToString("N0") + " lượt thích";
            likeCount.Font = new Font("Arial", 10, FontStyle.Bold);
            likeCount.Location = new Point(15, 5);
            likeCount.AutoSize = true;

            // Caption
            Label description = new Label();
            description.Text = username + "   " + caption;
            description.Font = new Font("Arial", 9);
            description.Location = new Point(15, 28);
            description.AutoSize = true;

            Label comments = new Label();
            comments.Text = "Xem tất cả bình luận...";
            comments.ForeColor = Color.Gray;
            comments.Font = new Font("Arial", 9);
            comments.Location = new Point(15, 58);
            comments.AutoSize = true;
            comments.Cursor = Cursors.Hand;

            TextBox commentInput = new TextBox();
            commentInput.BorderStyle = BorderStyle.None;
            commentInput.Font = new Font("Arial", 9);
            commentInput.ForeColor = Color.Gray;
            commentInput.Text = "Thêm bình luận...";
            commentInput.Location = new Point(15, 85);
            commentInput.Width = 350;

            Panel details = new Panel();
            details.Dock = DockStyle.Top;
            details.Height = 120;
            details.BackColor = Color.White;

            details.Controls.Add(likeCount);
            details.Controls.Add(description);
            details.Controls.Add(comments);
            details.Controls.Add(commentInput);

            // Sap xep
            card.Controls.Add(details);
            card.Controls.Add(actions);
            card.Controls.Add(scene);
            card.Controls.Add(header);

            // Hieu ung like
            bool liked = false;

            likeButton.Click += (s, e) =>
            {
                liked = !liked;

                if (liked)
                {
                    likeButton.Text = "♥";
                    likeButton.ForeColor = Color.FromArgb(237, 73, 86);
                    likes++;
                }
                else
                {
                    likeButton.Text = "♡";
                    likeButton.ForeColor = Color.Black;
                    likes--;
                }

                likeCount.Text = likes.ToString("N0") + " lượt thích";
            };

            scene.DoubleClick += (s, e) =>
            {
                if (!liked)
                {
                    liked = true;
                    likeButton.Text = "♥";
                    likeButton.ForeColor = Color.FromArgb(237, 73, 86);
                    likes++;
                    likeCount.Text = likes.ToString("N0") + " lượt thích";
                }
            };

            commentButton.Click += (s, e) =>
            {
                commentInput.Focus();
            };

            shareButton.Click += (s, e) =>
            {
                MessageBox.Show("Chia sẻ bài viết của " + username);
            };

            saveButton.Click += (s, e) =>
            {
                saveButton.ForeColor = blue;
                MessageBox.Show("Đã lưu bài viết!");
            };

            more.Click += (s, e) =>
            {
                MessageBox.Show("Tùy chọn bài viết của " + username);
            };

            comments.Click += (s, e) =>
            {
                commentInput.Focus();
            };

            feedFlow.Controls.Add(card);
        }

        private Label CreateAction(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(40, 35);
            label.Font = new Font("Arial", 19);
            label.ForeColor = Color.Black;
            label.Cursor = Cursors.Hand;
            label.TextAlign = ContentAlignment.MiddleCenter;

            label.MouseEnter += (s, e) =>
            {
                label.ForeColor = blue;
            };

            label.MouseLeave += (s, e) =>
            {
                if (label.Text != "♥")
                    label.ForeColor = Color.Black;
            };

            return label;
        }

        private void UpdatePostWidths()
        {
            if (feedHost == null || feedFlow == null)
                return;

            int width = feedHost.ClientSize.Width - 35;

            if (width < 400)
                width = 400;

            foreach (Control control in feedFlow.Controls)
            {
                control.Width = width;
            }
        }

        // ==========================================
        // COT BEN PHAI
        // ==========================================

        private void CreateRightPanel()
        {
            int y = 5;

            // Tai khoan hien tai
            Panel account = CreateWhiteCard(300, 95);
            account.Location = new Point(5, y);

            StoryAvatar myAvatar = new StoryAvatar();
            myAvatar.Size = new Size(58, 58);
            myAvatar.Location = new Point(15, 17);
            myAvatar.Letter = "B";
            myAvatar.AvatarColor = blue;

            Label myName = new Label();
            myName.Text = currentUser;
            myName.Font = new Font("Arial", 11, FontStyle.Bold);
            myName.Location = new Point(85, 22);
            myName.AutoSize = true;

            Label myDescription = new Label();
            myDescription.Text = "Tên của bạn";
            myDescription.ForeColor = Color.Gray;
            myDescription.Font = new Font("Arial", 9);
            myDescription.Location = new Point(85, 48);
            myDescription.AutoSize = true;

            account.Controls.Add(myAvatar);
            account.Controls.Add(myName);
            account.Controls.Add(myDescription);

            rightPanel.Controls.Add(account);

            y += 115;

            // Tieu de goi y
            Label suggestionTitle = new Label();
            suggestionTitle.Text = "Gợi ý cho bạn";
            suggestionTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            suggestionTitle.ForeColor = Color.FromArgb(100, 100, 100);
            suggestionTitle.Location = new Point(10, y);
            suggestionTitle.AutoSize = true;

            rightPanel.Controls.Add(suggestionTitle);

            y += 35;

            // Danh sach ban be
            suggestionFlow = new FlowLayoutPanel();
            suggestionFlow.Location = new Point(5, y);
            suggestionFlow.Size = new Size(310, 420);
            suggestionFlow.FlowDirection = FlowDirection.TopDown;
            suggestionFlow.WrapContents = false;
            suggestionFlow.AutoScroll = true;
            suggestionFlow.BackColor = background;

            rightPanel.Controls.Add(suggestionFlow);

            AddSuggestion("ngocanh", "N", Color.FromArgb(185, 115, 210));
            AddSuggestion("minhthu", "M", Color.FromArgb(92, 185, 140));
            AddSuggestion("hoangnam", "H", Color.FromArgb(92, 185, 140));
            AddSuggestion("thanhdat", "T", Color.FromArgb(245, 170, 90));
            AddSuggestion("linhchi", "L", Color.FromArgb(85, 150, 225));
            AddSuggestion("quanghuy", "Q", Color.FromArgb(85, 150, 225));
            AddSuggestion("phuong", "P", Color.FromArgb(240, 100, 120));
            AddSuggestion("thanhngan", "T", blue);

            y += 440;

            // Ban be dang hoat dong
            Label onlineTitle = new Label();
            onlineTitle.Text = "Bạn bè đang hoạt động";
            onlineTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            onlineTitle.ForeColor = Color.FromArgb(100, 100, 100);
            onlineTitle.Location = new Point(10, y);
            onlineTitle.AutoSize = true;

            rightPanel.Controls.Add(onlineTitle);

            y += 40;

            AddOnlineFriend("ngocanh", "N", Color.FromArgb(185, 115, 210), y);
            y += 60;

            AddOnlineFriend("minhthu", "M", Color.FromArgb(92, 185, 140), y);
            y += 60;

            AddOnlineFriend("hoangnam", "H", Color.FromArgb(92, 185, 140), y);

            y += 90;

            // Chu de noi bat
            Label trendTitle = new Label();
            trendTitle.Text = "Khám phá";
            trendTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            trendTitle.ForeColor = Color.FromArgb(100, 100, 100);
            trendTitle.Location = new Point(10, y);
            trendTitle.AutoSize = true;

            rightPanel.Controls.Add(trendTitle);

            y += 35;

            AddTrend("#NT106_GROUP10", "Cộng đồng của chúng ta", y);
            y += 65;

            AddTrend("#Friends", "Kết nối bạn bè", y);
            y += 65;

            AddTrend("#Moments", "Khoảnh khắc mỗi ngày", y);
            y += 65;

            Label footer = new Label();
            footer.Text = "Giới thiệu  ·  Trợ giúp  ·  Quyền riêng tư\n© 2026 NT106 Social";
            footer.Font = new Font("Arial", 8);
            footer.ForeColor = Color.Gray;
            footer.Location = new Point(10, y + 15);
            footer.AutoSize = true;

            rightPanel.Controls.Add(footer);
        }

        // ==========================================
        // GOI Y BAN BE
        // ==========================================

        private void AddSuggestion(
            string username,
            string letter,
            Color avatarColor)
        {
            Panel item = new Panel();
            item.Size = new Size(290, 65);
            item.BackColor = Color.White;
            item.Margin = new Padding(0, 2, 0, 5);

            StoryAvatar avatar = new StoryAvatar();
            avatar.Size = new Size(43, 43);
            avatar.Location = new Point(8, 10);
            avatar.Letter = letter;
            avatar.AvatarColor = avatarColor;

            Label name = new Label();
            name.Text = username;
            name.Font = new Font("Arial", 9, FontStyle.Bold);
            name.Location = new Point(65, 12);
            name.AutoSize = true;

            Label mutual = new Label();
            mutual.Text = "Có thể bạn biết";
            mutual.Font = new Font("Arial", 8);
            mutual.ForeColor = Color.Gray;
            mutual.Location = new Point(65, 34);
            mutual.AutoSize = true;

            Button follow = new Button();
            follow.Text = "Follow";
            follow.Font = new Font("Arial", 9, FontStyle.Bold);
            follow.ForeColor = blue;
            follow.BackColor = Color.White;
            follow.FlatStyle = FlatStyle.Flat;
            follow.FlatAppearance.BorderSize = 0;
            follow.Size = new Size(65, 30);
            follow.Location = new Point(210, 17);
            follow.Cursor = Cursors.Hand;

            follow.Click += (s, e) =>
            {
                if (follow.Text == "Follow")
                {
                    follow.Text = "Following";
                    follow.ForeColor = Color.Gray;
                }
                else
                {
                    follow.Text = "Follow";
                    follow.ForeColor = blue;
                }
            };

            item.Controls.Add(avatar);
            item.Controls.Add(name);
            item.Controls.Add(mutual);
            item.Controls.Add(follow);

            item.MouseEnter += (s, e) =>
            {
                item.BackColor = Color.FromArgb(240, 247, 255);
            };

            item.MouseLeave += (s, e) =>
            {
                item.BackColor = Color.White;
            };

            suggestionFlow.Controls.Add(item);
        }

        // ==========================================
        // BAN BE ONLINE
        // ==========================================

        private void AddOnlineFriend(
            string username,
            string letter,
            Color color,
            int y)
        {
            StoryAvatar avatar = new StoryAvatar();
            avatar.Size = new Size(38, 38);
            avatar.Location = new Point(10, y);
            avatar.Letter = letter;
            avatar.AvatarColor = color;

            Label name = new Label();
            name.Text = username;
            name.Font = new Font("Arial", 9, FontStyle.Bold);
            name.Location = new Point(60, y + 10);
            name.AutoSize = true;

            Panel online = new Panel();
            online.Size = new Size(10, 10);
            online.Location = new Point(210, y + 14);
            online.BackColor = Color.FromArgb(49, 190, 95);

            online.Region = new Region(
                new Rectangle(0, 0, 10, 10));

            rightPanel.Controls.Add(avatar);
            rightPanel.Controls.Add(name);
            rightPanel.Controls.Add(online);
        }

        // ==========================================
        // KHU VUC KHÁM PHA
        // ==========================================

        private void AddTrend(
            string hashtag,
            string description,
            int y)
        {
            Panel item = new Panel();
            item.Location = new Point(5, y);
            item.Size = new Size(290, 55);
            item.BackColor = Color.White;

            Label tag = new Label();
            tag.Text = hashtag;
            tag.Font = new Font("Arial", 10, FontStyle.Bold);
            tag.ForeColor = blue;
            tag.Location = new Point(10, 5);
            tag.AutoSize = true;

            Label detail = new Label();
            detail.Text = description;
            detail.Font = new Font("Arial", 8);
            detail.ForeColor = Color.Gray;
            detail.Location = new Point(10, 28);
            detail.AutoSize = true;

            item.Controls.Add(tag);
            item.Controls.Add(detail);

            rightPanel.Controls.Add(item);
        }

        // ==========================================
        // HAM TAO CARD
        // ==========================================

        private Panel CreateWhiteCard(int width, int height)
        {
            Panel panel = new Panel();
            panel.Size = new Size(width, height);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            return panel;
        }
    }

    // ==============================================
    // AVATAR CO VIEN GRADIENT
    // ==============================================

    public class StoryAvatar : Panel
    {
        public string Letter { get; set; }
        public Color AvatarColor { get; set; }
        public bool IsOwn { get; set; }

        public StoryAvatar()
        {
            DoubleBuffered = true;
            Letter = "A";
            AvatarColor = Color.DodgerBlue;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int size = Math.Min(Width, Height);

            Rectangle outer = new Rectangle(
                2, 2, size - 4, size - 4);

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    outer,
                    Color.FromArgb(255, 190, 80),
                    Color.FromArgb(210, 55, 145),
                    45f))
            using (Pen pen = new Pen(brush, 5))
            {
                g.DrawEllipse(pen, outer);
            }

            Rectangle inner = new Rectangle(
                7, 7, size - 14, size - 14);

            using (SolidBrush brush = new SolidBrush(AvatarColor))
            {
                g.FillEllipse(brush, inner);
            }

            using (Font font = new Font(
                "Arial",
                Math.Max(12, size / 2),
                FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString(
                    IsOwn ? "+" : Letter,
                    font,
                    textBrush,
                    inner,
                    sf);
            }
        }
    }

    // ==============================================
    // ANH BAI DANG GRADIENT
    // ==============================================

    public class SceneImage : Panel
    {
        public string ImageTitle { get; set; }
        public int StyleIndex { get; set; }

        public SceneImage()
        {
            DoubleBuffered = true;
            ImageTitle = "SUNSET";
            StyleIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;

            Color top;
            Color bottom;
            Color mountain;

            if (StyleIndex == 1)
            {
                top = Color.FromArgb(255, 190, 130);
                bottom = Color.FromArgb(255, 110, 130);
                mountain = Color.FromArgb(125, 70, 125);
            }
            else if (StyleIndex == 2)
            {
                top = Color.FromArgb(100, 180, 230);
                bottom = Color.FromArgb(200, 230, 240);
                mountain = Color.FromArgb(55, 110, 125);
            }
            else if (StyleIndex == 3)
            {
                top = Color.FromArgb(255, 210, 130);
                bottom = Color.FromArgb(255, 130, 90);
                mountain = Color.FromArgb(100, 85, 115);
            }
            else
            {
                top = Color.FromArgb(225, 165, 140);
                bottom = Color.FromArgb(145, 125, 165);
                mountain = Color.FromArgb(65, 78, 120);
            }

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    rect, top, bottom, 90f))
            {
                g.FillRectangle(brush, rect);
            }

            // Mat troi
            int sunSize = Math.Max(55, Height / 5);

            using (SolidBrush sunBrush =
                new SolidBrush(Color.FromArgb(255, 235, 170)))
            {
                g.FillEllipse(
                    sunBrush,
                    Width - sunSize - 55,
                    35,
                    sunSize,
                    sunSize);
            }

            // Nui phia sau
            Point[] mountain1 =
            {
                new Point(0, Height * 3 / 4),
                new Point(Width / 3, Height / 3),
                new Point(Width * 2 / 3, Height * 3 / 4),
                new Point(Width, Height / 2),
                new Point(Width, Height),
                new Point(0, Height)
            };

            using (SolidBrush mountainBrush =
                new SolidBrush(mountain))
            {
                g.FillPolygon(mountainBrush, mountain1);
            }

            // Chu tren anh
            using (Font font =
                new Font("Arial", 30, FontStyle.Bold))
            using (SolidBrush white =
                new SolidBrush(Color.White))
            {
                g.DrawString(
                    ImageTitle,
                    font,
                    white,
                    30,
                    Height - 85);
            }
        }
    }
}
