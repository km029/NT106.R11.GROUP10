namespace NT106_GROUP10
{
    partial class ProfileControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Card = new System.Windows.Forms.Panel();
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
            this.Card.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Card.BackColor = System.Drawing.Color.White;
            this.Card.Controls.Add(this.linePhanCach);
            this.Card.Controls.Add(this.EditProfile);
            this.Card.Controls.Add(this.ChangeAvatar);
            this.Card.Controls.Add(this.lblFriendsCount);
            this.Card.Controls.Add(this.lblPostsCount);
            this.Card.Controls.Add(this.lblAccountName);
            this.Card.Controls.Add(this.lblUsername);
            this.Card.Controls.Add(this.Avatar);
            this.Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.Card.Location = new System.Drawing.Point(131, 0);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(860, 803);
            this.Card.TabIndex = 0;
            // 
            // linePhanCach
            // 
            this.linePhanCach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.linePhanCach.Location = new System.Drawing.Point(30, 290);
            this.linePhanCach.Name = "linePhanCach";
            this.linePhanCach.Size = new System.Drawing.Size(800, 1);
            this.linePhanCach.TabIndex = 7;
            // 
            // EditProfile
            // 
            this.EditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.EditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EditProfile.FlatAppearance.BorderSize = 0;
            this.EditProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.EditProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.EditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.EditProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditProfile.Location = new System.Drawing.Point(440, 220);
            this.EditProfile.Name = "EditProfile";
            this.EditProfile.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.EditProfile.Size = new System.Drawing.Size(370, 45);
            this.EditProfile.TabIndex = 6;
            this.EditProfile.Text = "Chỉnh sửa trang cá nhân";
            this.EditProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditProfile.UseVisualStyleBackColor = false;
            // 
            // ChangeAvatar
            // 
            this.ChangeAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.ChangeAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeAvatar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeAvatar.FlatAppearance.BorderSize = 0;
            this.ChangeAvatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.ChangeAvatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.ChangeAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ChangeAvatar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeAvatar.Location = new System.Drawing.Point(50, 220);
            this.ChangeAvatar.Name = "ChangeAvatar";
            this.ChangeAvatar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.ChangeAvatar.Size = new System.Drawing.Size(370, 45);
            this.ChangeAvatar.TabIndex = 5;
            this.ChangeAvatar.Text = "Đổi ảnh đại diện";
            this.ChangeAvatar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeAvatar.UseVisualStyleBackColor = false;
            // 
            // lblFriendsCount
            // 
            this.lblFriendsCount.AutoSize = true;
            this.lblFriendsCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFriendsCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriendsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFriendsCount.Location = new System.Drawing.Point(390, 108);
            this.lblFriendsCount.Name = "lblFriendsCount";
            this.lblFriendsCount.Size = new System.Drawing.Size(63, 23);
            this.lblFriendsCount.TabIndex = 4;
            this.lblFriendsCount.Text = "bạn bè";
            // 
            // lblPostsCount
            // 
            this.lblPostsCount.AutoSize = true;
            this.lblPostsCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPostsCount.Location = new System.Drawing.Point(290, 108);
            this.lblPostsCount.Name = "lblPostsCount";
            this.lblPostsCount.Size = new System.Drawing.Size(65, 23);
            this.lblPostsCount.TabIndex = 3;
            this.lblPostsCount.Text = "bài viết";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblAccountName.Location = new System.Drawing.Point(290, 75);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(148, 28);
            this.lblAccountName.TabIndex = 2;
            this.lblAccountName.Text = "Account name";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUsername.Location = new System.Drawing.Point(290, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(148, 38);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // Avatar
            // 
            this.Avatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.Avatar.Location = new System.Drawing.Point(90, 35);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(150, 150);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.Card);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(1122, 803);
            this.Card.ResumeLayout(false);
            this.Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Card;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblPostsCount;
        private System.Windows.Forms.Label lblFriendsCount;
        private System.Windows.Forms.Button ChangeAvatar;
        private System.Windows.Forms.Button EditProfile;
        private System.Windows.Forms.Panel linePhanCach;
    }
}
