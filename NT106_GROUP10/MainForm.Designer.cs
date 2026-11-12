namespace NT106_GROUP10
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Menu = new System.Windows.Forms.Panel();
            this.Content = new System.Windows.Forms.Panel();
            this.DuongKe = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.Button();
            this.Reels = new System.Windows.Forms.Button();
            this.Profile = new System.Windows.Forms.Button();
            this.Messenger = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.White;
            this.Menu.Controls.Add(this.Search);
            this.Menu.Controls.Add(this.Reels);
            this.Menu.Controls.Add(this.Profile);
            this.Menu.Controls.Add(this.Messenger);
            this.Menu.Controls.Add(this.Logout);
            this.Menu.Controls.Add(this.Home);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(300, 803);
            this.Menu.TabIndex = 0;
            // 
            // Content
            // 
            this.Content.BackColor = System.Drawing.Color.White;
            this.Content.Controls.Add(this.DuongKe);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(300, 0);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(1122, 803);
            this.Content.TabIndex = 1;
            // 
            // DuongKe
            // 
            this.DuongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.DuongKe.Dock = System.Windows.Forms.DockStyle.Left;
            this.DuongKe.Location = new System.Drawing.Point(0, 0);
            this.DuongKe.Name = "DuongKe";
            this.DuongKe.Size = new System.Drawing.Size(1, 803);
            this.DuongKe.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Search.FlatAppearance.BorderSize = 0;
            this.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Image = global::NT106_GROUP10.Properties.Resources.ic_search_line;
            this.Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Search.Location = new System.Drawing.Point(15, 380);
            this.Search.Name = "Search";
            this.Search.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Search.Size = new System.Drawing.Size(265, 58);
            this.Search.TabIndex = 7;
            this.Search.Text = "  Tìm kiếm";
            this.Search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Search.UseVisualStyleBackColor = false;
            // 
            // Reels
            // 
            this.Reels.BackColor = System.Drawing.Color.White;
            this.Reels.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Reels.FlatAppearance.BorderSize = 0;
            this.Reels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Reels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Reels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reels.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reels.ForeColor = System.Drawing.Color.Black;
            this.Reels.Image = global::NT106_GROUP10.Properties.Resources.ic_reels_line1;
            this.Reels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reels.Location = new System.Drawing.Point(15, 240);
            this.Reels.Name = "Reels";
            this.Reels.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Reels.Size = new System.Drawing.Size(265, 58);
            this.Reels.TabIndex = 6;
            this.Reels.Text = "  Video ngắn";
            this.Reels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Reels.UseVisualStyleBackColor = false;
            // 
            // Profile
            // 
            this.Profile.BackColor = System.Drawing.Color.White;
            this.Profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Profile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Profile.FlatAppearance.BorderSize = 0;
            this.Profile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Profile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Profile.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profile.ForeColor = System.Drawing.Color.Black;
            this.Profile.Image = global::NT106_GROUP10.Properties.Resources.ic_profile_line_36;
            this.Profile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profile.Location = new System.Drawing.Point(15, 450);
            this.Profile.Name = "Profile";
            this.Profile.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Profile.Size = new System.Drawing.Size(265, 58);
            this.Profile.TabIndex = 5;
            this.Profile.Text = "  Trang cá nhân";
            this.Profile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Profile.UseVisualStyleBackColor = false;
            // 
            // Messenger
            // 
            this.Messenger.BackColor = System.Drawing.Color.White;
            this.Messenger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Messenger.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Messenger.FlatAppearance.BorderSize = 0;
            this.Messenger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Messenger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Messenger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Messenger.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Messenger.ForeColor = System.Drawing.Color.Black;
            this.Messenger.Image = global::NT106_GROUP10.Properties.Resources.ic_messenger_line;
            this.Messenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Messenger.Location = new System.Drawing.Point(15, 310);
            this.Messenger.Name = "Messenger";
            this.Messenger.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Messenger.Size = new System.Drawing.Size(265, 58);
            this.Messenger.TabIndex = 4;
            this.Messenger.Text = "  Tin nhắn";
            this.Messenger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Messenger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Messenger.UseVisualStyleBackColor = false;
            // 
            // Logout
            // 
            this.Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Logout.FlatAppearance.BorderSize = 0;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.ForeColor = System.Drawing.Color.Black;
            this.Logout.Image = global::NT106_GROUP10.Properties.Resources.ic_logout_line_;
            this.Logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Logout.Location = new System.Drawing.Point(15, 734);
            this.Logout.Name = "Logout";
            this.Logout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Logout.Size = new System.Drawing.Size(265, 58);
            this.Logout.TabIndex = 3;
            this.Logout.Text = "  Đăng xuất";
            this.Logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.White;
            this.Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Home.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Home.FlatAppearance.BorderSize = 0;
            this.Home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.Black;
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Home.Location = new System.Drawing.Point(15, 170);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Home.Size = new System.Drawing.Size(265, 58);
            this.Home.TabIndex = 1;
            this.Home.Text = "  Trang chủ";
            this.Home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Home.UseVisualStyleBackColor = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1422, 803);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Menu);
            this.Name = "MainForm";
            this.Text = "App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Menu.ResumeLayout(false);
            this.Content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Panel DuongKe;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button Messenger;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Reels;
    }
}