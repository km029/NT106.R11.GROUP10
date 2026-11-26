namespace NT106_GROUP10
{
    partial class EditProfileControl
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.pnlDisplayNameBox = new System.Windows.Forms.Panel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlUsernameBox = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblBio = new System.Windows.Forms.Label();
            this.pnlBioBox = new System.Windows.Forms.Panel();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.pnlGenderBox = new System.Windows.Forms.Panel();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlContainer.SuspendLayout();
            this.pnlDisplayNameBox.SuspendLayout();
            this.pnlUsernameBox.SuspendLayout();
            this.pnlBioBox.SuspendLayout();
            this.pnlGenderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.pnlGenderBox);
            this.pnlContainer.Controls.Add(this.lblGender);
            this.pnlContainer.Controls.Add(this.pnlBioBox);
            this.pnlContainer.Controls.Add(this.lblBio);
            this.pnlContainer.Controls.Add(this.pnlUsernameBox);
            this.pnlContainer.Controls.Add(this.lblUsername);
            this.pnlContainer.Controls.Add(this.pnlDisplayNameBox);
            this.pnlContainer.Controls.Add(this.lblDisplayName);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.btnBack);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(30, 20, 30, 30);
            this.pnlContainer.Size = new System.Drawing.Size(700, 660);
            this.pnlContainer.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(40, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 36);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(92, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chỉnh sửa trang cá nhân";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDisplayName.Location = new System.Drawing.Point(40, 82);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(96, 19);
            this.lblDisplayName.TabIndex = 2;
            this.lblDisplayName.Text = "Tên hiển thị";
            // 
            // pnlDisplayNameBox
            // 
            this.pnlDisplayNameBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlDisplayNameBox.Controls.Add(this.txtDisplayName);
            this.pnlDisplayNameBox.Location = new System.Drawing.Point(40, 108);
            this.pnlDisplayNameBox.Name = "pnlDisplayNameBox";
            this.pnlDisplayNameBox.Size = new System.Drawing.Size(610, 48);
            this.pnlDisplayNameBox.TabIndex = 3;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisplayName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDisplayName.Location = new System.Drawing.Point(16, 14);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(578, 20);
            this.txtDisplayName.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUsername.Location = new System.Drawing.Point(40, 174);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 19);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // pnlUsernameBox
            // 
            this.pnlUsernameBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlUsernameBox.Controls.Add(this.txtUsername);
            this.pnlUsernameBox.Location = new System.Drawing.Point(40, 200);
            this.pnlUsernameBox.Name = "pnlUsernameBox";
            this.pnlUsernameBox.Size = new System.Drawing.Size(610, 48);
            this.pnlUsernameBox.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(16, 14);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(578, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblBio.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblBio.Location = new System.Drawing.Point(40, 266);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(61, 19);
            this.lblBio.TabIndex = 6;
            this.lblBio.Text = "Tiểu sử";
            // 
            // pnlBioBox
            // 
            this.pnlBioBox.BackColor = System.Drawing.Color.White;
            this.pnlBioBox.Controls.Add(this.txtBio);
            this.pnlBioBox.Location = new System.Drawing.Point(40, 292);
            this.pnlBioBox.Name = "pnlBioBox";
            this.pnlBioBox.Size = new System.Drawing.Size(610, 96);
            this.pnlBioBox.TabIndex = 7;
            // 
            // txtBio
            // 
            this.txtBio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBio.Location = new System.Drawing.Point(16, 12);
            this.txtBio.MaxLength = 150;
            this.txtBio.Multiline = true;
            this.txtBio.Name = "txtBio";
            this.txtBio.Size = new System.Drawing.Size(578, 72);
            this.txtBio.TabIndex = 0;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGender.Location = new System.Drawing.Point(40, 406);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(72, 19);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Giới tính";
            // 
            // pnlGenderBox
            // 
            this.pnlGenderBox.BackColor = System.Drawing.Color.White;
            this.pnlGenderBox.Controls.Add(this.cboGender);
            this.pnlGenderBox.Location = new System.Drawing.Point(40, 432);
            this.pnlGenderBox.Name = "pnlGenderBox";
            this.pnlGenderBox.Size = new System.Drawing.Size(610, 50);
            this.pnlGenderBox.TabIndex = 9;
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Không muốn tiết lộ",
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGender.Location = new System.Drawing.Point(14, 11);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(582, 27);
            this.cboGender.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(48, 116, 235);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(470, 508);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 44);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContainer);
            this.Name = "EditProfileControl";
            this.Size = new System.Drawing.Size(700, 660);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlDisplayNameBox.ResumeLayout(false);
            this.pnlDisplayNameBox.PerformLayout();
            this.pnlUsernameBox.ResumeLayout(false);
            this.pnlUsernameBox.PerformLayout();
            this.pnlBioBox.ResumeLayout(false);
            this.pnlBioBox.PerformLayout();
            this.pnlGenderBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Panel pnlDisplayNameBox;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUsernameBox;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Panel pnlBioBox;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Panel pnlGenderBox;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Button btnSave;
    }
}