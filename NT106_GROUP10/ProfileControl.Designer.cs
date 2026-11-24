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
            this.components = new System.ComponentModel.Container();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.Card.Location = new System.Drawing.Point(123, 20);
            this.Card.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(876, 680);
            this.Card.TabIndex = 0;
            this.Card.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // flpFriends
            // 
            this.flpFriends.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpFriends.AutoScroll = true;
            this.flpFriends.BackColor = System.Drawing.Color.White;
            this.flpFriends.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFriends.Location = new System.Drawing.Point(30, 296);
            this.flpFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpFriends.Name = "flpFriends";
            this.flpFriends.Size = new System.Drawing.Size(815, 352);
            this.flpFriends.TabIndex = 12;
            this.flpFriends.Visible = false;
            this.flpFriends.WrapContents = false;
            // 
            // flpContent
            // 
            this.flpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContent.AutoScroll = true;
            this.flpContent.BackColor = System.Drawing.Color.White;
            this.flpContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpContent.Location = new System.Drawing.Point(30, 296);
            this.flpContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpContent.Name = "flpContent";
            this.flpContent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpContent.Size = new System.Drawing.Size(815, 352);
            this.flpContent.TabIndex = 11;
            this.flpContent.WrapContents = false;
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(116)))), ((int)(((byte)(235)))));
            this.pnlIndicator.Location = new System.Drawing.Point(30, 285);
            this.pnlIndicator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(403, 3);
            this.pnlIndicator.TabIndex = 0;
            // 
            // btnTabFriends
            // 
            this.btnTabFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabFriends.FlatAppearance.BorderSize = 0;
            this.btnTabFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabFriends.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTabFriends.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTabFriends.Location = new System.Drawing.Point(435, 240);
            this.btnTabFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTabFriends.Name = "btnTabFriends";
            this.btnTabFriends.Size = new System.Drawing.Size(396, 48);
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
            this.btnTabInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(116)))), ((int)(((byte)(235)))));
            this.btnTabInfo.Location = new System.Drawing.Point(30, 240);
            this.btnTabInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTabInfo.Name = "btnTabInfo";
            this.btnTabInfo.Size = new System.Drawing.Size(403, 48);
            this.btnTabInfo.TabIndex = 9;
            this.btnTabInfo.Text = "Thông tin cá nhân";
            this.btnTabInfo.UseVisualStyleBackColor = true;
            this.btnTabInfo.Click += new System.EventHandler(this.btnTabInfo_Click);
            // 
            // linePhanCach
            // 
            this.linePhanCach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.linePhanCach.Location = new System.Drawing.Point(30, 238);
            this.linePhanCach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.linePhanCach.Name = "linePhanCach";
            this.linePhanCach.Size = new System.Drawing.Size(800, 1);
            this.linePhanCach.TabIndex = 13;
            // 
            // EditProfile
            // 
            this.EditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.EditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditProfile.FlatAppearance.BorderSize = 0;
            this.EditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.EditProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.EditProfile.Location = new System.Drawing.Point(464, 176);
            this.EditProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditProfile.Name = "EditProfile";
            this.EditProfile.Size = new System.Drawing.Size(358, 37);
            this.EditProfile.TabIndex = 6;
            this.EditProfile.Text = "Chỉnh sửa trang cá nhân";
            this.EditProfile.UseVisualStyleBackColor = false;
            this.EditProfile.Click += new System.EventHandler(this.EditProfile_Click);
            // 
            // ChangeAvatar
            // 
            this.ChangeAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(116)))), ((int)(((byte)(235)))));
            this.ChangeAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeAvatar.FlatAppearance.BorderSize = 0;
            this.ChangeAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ChangeAvatar.ForeColor = System.Drawing.Color.White;
            this.ChangeAvatar.Location = new System.Drawing.Point(53, 176);
            this.ChangeAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangeAvatar.Name = "ChangeAvatar";
            this.ChangeAvatar.Size = new System.Drawing.Size(380, 37);
            this.ChangeAvatar.TabIndex = 5;
            this.ChangeAvatar.Text = "Đổi ảnh đại diện";
            this.ChangeAvatar.UseVisualStyleBackColor = false;
            this.ChangeAvatar.Click += new System.EventHandler(this.ChangeAvatar_Click);
            // 
            // lblFriendsCount
            // 
            this.lblFriendsCount.BackColor = System.Drawing.Color.White;
            this.lblFriendsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFriendsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.lblFriendsCount.Location = new System.Drawing.Point(347, 132);
            this.lblFriendsCount.Name = "lblFriendsCount";
            this.lblFriendsCount.Size = new System.Drawing.Size(124, 20);
            this.lblFriendsCount.TabIndex = 14;
            this.lblFriendsCount.Text = "0 bạn bè";
            this.lblFriendsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPostsCount
            // 
            this.lblPostsCount.BackColor = System.Drawing.Color.White;
            this.lblPostsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPostsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(116)))), ((int)(((byte)(235)))));
            this.lblPostsCount.Location = new System.Drawing.Point(234, 132);
            this.lblPostsCount.Name = "lblPostsCount";
            this.lblPostsCount.Size = new System.Drawing.Size(107, 20);
            this.lblPostsCount.TabIndex = 15;
            this.lblPostsCount.Text = "0 bài viết";
            this.lblPostsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoEllipsis = true;
            this.lblAccountName.BackColor = System.Drawing.Color.White;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.lblAccountName.Location = new System.Drawing.Point(234, 84);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(578, 30);
            this.lblAccountName.TabIndex = 16;
            this.lblAccountName.Text = "Tên hiển thị";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoEllipsis = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.lblUsername.Location = new System.Drawing.Point(229, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(578, 48);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Avatar
            // 
            this.Avatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.Avatar.Location = new System.Drawing.Point(67, 34);
            this.Avatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(133, 120);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.Card);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(1122, 720);
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
        private System.Windows.Forms.Timer timer1;
    }
}
