namespace NT106_GROUP10
{
    partial class ProfileControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Card = new System.Windows.Forms.Panel();
            this.flpFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.btnTabFriends = new System.Windows.Forms.Button();
            this.btnTabInfo = new System.Windows.Forms.Button();
            this.linePhanCach = new System.Windows.Forms.Panel();
            this.EditProfile = new System.Windows.Forms.Button();
            this.ChangeAvatar = new System.Windows.Forms.Button();
            this.lblFriendsCount = new System.Windows.Forms.Label();
            this.lblPostsCount = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // Card
            // 
            this.Card.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card.BackColor = System.Drawing.Color.White;
            this.Card.Controls.Add(this.flpFriends);
            this.Card.Controls.Add(this.flpContent);
            this.Card.Controls.Add(this.pnlIndicator);
            this.Card.Controls.Add(this.btnTabFriends);
            this.Card.Controls.Add(this.btnTabInfo);
            this.Card.Controls.Add(this.linePhanCach);
            this.Card.Controls.Add(this.EditProfile);
            this.Card.Controls.Add(this.ChangeAvatar);
            this.Card.Controls.Add(this.lblFriendsCount);
            this.Card.Controls.Add(this.lblPostsCount);
            this.Card.Controls.Add(this.lblAccountName);
            this.Card.Controls.Add(this.lblUsername);
            this.Card.Controls.Add(this.Avatar);
            this.Card.Location = new System.Drawing.Point(138, 25);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(985, 850);
            this.Card.TabIndex = 0;
            this.Card.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // flpFriends
            // 
            this.flpFriends.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) |
                System.Windows.Forms.AnchorStyles.Right)));
            this.flpFriends.AutoScroll = true;
            this.flpFriends.BackColor = System.Drawing.Color.White;
            this.flpFriends.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFriends.Location = new System.Drawing.Point(34, 370);
            this.flpFriends.Name = "flpFriends";
            this.flpFriends.Size = new System.Drawing.Size(917, 440);
            this.flpFriends.TabIndex = 12;
            this.flpFriends.Visible = false;
            this.flpFriends.WrapContents = false;
            // 
            // flpContent
            // 
            this.flpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) |
                System.Windows.Forms.AnchorStyles.Right)));
            this.flpContent.AutoScroll = true;
            this.flpContent.BackColor = System.Drawing.Color.White;
            this.flpContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpContent.Location = new System.Drawing.Point(34, 370);
            this.flpContent.Name = "flpContent";
            this.flpContent.Padding = new System.Windows.Forms.Padding(5);
            this.flpContent.Size = new System.Drawing.Size(917, 440);
            this.flpContent.TabIndex = 11;
            this.flpContent.WrapContents = false;
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(48, 116, 235);
            this.pnlIndicator.Location = new System.Drawing.Point(34, 356);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(453, 4);
            this.pnlIndicator.TabIndex = 0;
            // 
            // btnTabFriends
            // 
            this.btnTabFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabFriends.FlatAppearance.BorderSize = 0;
            this.btnTabFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabFriends.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTabFriends.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnTabFriends.Location = new System.Drawing.Point(489, 300);
            this.btnTabFriends.Name = "btnTabFriends";
            this.btnTabFriends.Size = new System.Drawing.Size(445, 60);
            this.btnTabFriends.TabIndex = 10;
            this.btnTabFriends.Text = "Bạn bè";
            this.btnTabFriends.UseVisualStyleBackColor = true;
            this.btnTabFriends.Click += new System.EventHandler(this.btnTabFriends_Click);
            // 
            // btnTabInfo
            // 
            this.btnTabInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabInfo.FlatAppearance.BorderSize = 0;
            this.btnTabInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTabInfo.ForeColor = System.Drawing.Color.FromArgb(48, 116, 235);
            this.btnTabInfo.Location = new System.Drawing.Point(34, 300);
            this.btnTabInfo.Name = "btnTabInfo";
            this.btnTabInfo.Size = new System.Drawing.Size(453, 60);
            this.btnTabInfo.TabIndex = 9;
            this.btnTabInfo.Text = "Thông tin cá nhân";
            this.btnTabInfo.UseVisualStyleBackColor = true;
            this.btnTabInfo.Click += new System.EventHandler(this.btnTabInfo_Click);
            // 
            // linePhanCach
            // 
            this.linePhanCach.BackColor = System.Drawing.Color.FromArgb(229, 234, 242);
            this.linePhanCach.Location = new System.Drawing.Point(34, 298);
            this.linePhanCach.Name = "linePhanCach";
            this.linePhanCach.Size = new System.Drawing.Size(900, 1);
            this.linePhanCach.TabIndex = 13;
            // 
            // EditProfile
            // 
            this.EditProfile.BackColor = System.Drawing.Color.FromArgb(235, 243, 255);
            this.EditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditProfile.FlatAppearance.BorderSize = 0;
            this.EditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.EditProfile.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.EditProfile.Location = new System.Drawing.Point(522, 220);
            this.EditProfile.Name = "EditProfile";
            this.EditProfile.Size = new System.Drawing.Size(403, 46);
            this.EditProfile.TabIndex = 6;
            this.EditProfile.Text = "Chỉnh sửa trang cá nhân";
            this.EditProfile.UseVisualStyleBackColor = false;
            // 
            // ChangeAvatar
            // 
            this.ChangeAvatar.BackColor = System.Drawing.Color.FromArgb(48, 116, 235);
            this.ChangeAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeAvatar.FlatAppearance.BorderSize = 0;
            this.ChangeAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ChangeAvatar.ForeColor = System.Drawing.Color.White;
            this.ChangeAvatar.Location = new System.Drawing.Point(60, 220);
            this.ChangeAvatar.Name = "ChangeAvatar";
            this.ChangeAvatar.Size = new System.Drawing.Size(427, 46);
            this.ChangeAvatar.TabIndex = 5;
            this.ChangeAvatar.Text = "Đổi ảnh đại diện";
            this.ChangeAvatar.UseVisualStyleBackColor = false;
            // 
            // lblFriendsCount
            // 
            this.lblFriendsCount.BackColor = System.Drawing.Color.White;
            this.lblFriendsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFriendsCount.ForeColor = System.Drawing.Color.FromArgb(35, 51, 75);
            this.lblFriendsCount.Location = new System.Drawing.Point(390, 165);
            this.lblFriendsCount.Name = "lblFriendsCount";
            this.lblFriendsCount.Size = new System.Drawing.Size(140, 25);
            this.lblFriendsCount.TabIndex = 14;
            this.lblFriendsCount.Text = "0 bạn bè";
            this.lblFriendsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPostsCount
            // 
            this.lblPostsCount.BackColor = System.Drawing.Color.White;
            this.lblPostsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPostsCount.ForeColor = System.Drawing.Color.FromArgb(48, 116, 235);
            this.lblPostsCount.Location = new System.Drawing.Point(263, 165);
            this.lblPostsCount.Name = "lblPostsCount";
            this.lblPostsCount.Size = new System.Drawing.Size(120, 25);
            this.lblPostsCount.TabIndex = 15;
            this.lblPostsCount.Text = "0 bài viết";
            this.lblPostsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoEllipsis = true;
            this.lblAccountName.BackColor = System.Drawing.Color.White;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(35, 51, 75);
            this.lblAccountName.Location = new System.Drawing.Point(263, 105);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(650, 38);
            this.lblAccountName.TabIndex = 16;
            this.lblAccountName.Text = "Tên hiển thị";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoEllipsis = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(35, 51, 75);
            this.lblUsername.Location = new System.Drawing.Point(258, 42);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(650, 60);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Avatar
            // 
            this.Avatar.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.Avatar.Location = new System.Drawing.Point(75, 43);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(150, 150);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 252);
            this.Controls.Add(this.Card);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(1262, 900);
            this.Card.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel Card;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblPostsCount;
        private System.Windows.Forms.Label lblFriendsCount;
        private System.Windows.Forms.Button ChangeAvatar;
        private System.Windows.Forms.Button EditProfile;
        private System.Windows.Forms.Panel linePhanCach;
        private System.Windows.Forms.Button btnTabFriends;
        private System.Windows.Forms.Button btnTabInfo;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.FlowLayoutPanel flpFriends;
    }
}
