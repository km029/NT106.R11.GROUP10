namespace NT106_GROUP10
{
    partial class RegisterForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtRegUsername = new System.Windows.Forms.TextBox();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnDoRegister = new System.Windows.Forms.Button();
            this.lnkBackToLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(40, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.Location = new System.Drawing.Point(60, 83);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(140, 28);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên đăng nhập";
            // 
            // txtRegUsername
            // 
            this.txtRegUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRegUsername.Location = new System.Drawing.Point(65, 114);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.Size = new System.Drawing.Size(330, 37);
            this.txtRegUsername.TabIndex = 2;
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRegPassword.Location = new System.Drawing.Point(65, 269);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.Size = new System.Drawing.Size(330, 37);
            this.txtRegPassword.TabIndex = 3;
            this.txtRegPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(60, 238);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 28);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(60, 319);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(177, 28);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(65, 350);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(330, 37);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // btnDoRegister
            // 
            this.btnDoRegister.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDoRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDoRegister.ForeColor = System.Drawing.Color.White;
            this.btnDoRegister.Location = new System.Drawing.Point(60, 416);
            this.btnDoRegister.Name = "btnDoRegister";
            this.btnDoRegister.Size = new System.Drawing.Size(330, 40);
            this.btnDoRegister.TabIndex = 7;
            this.btnDoRegister.Text = "ĐĂNG KÝ NGAY";
            this.btnDoRegister.UseVisualStyleBackColor = false;
            this.btnDoRegister.Click += new System.EventHandler(this.btnDoRegister_Click);
            // 
            // lnkBackToLogin
            // 
            this.lnkBackToLogin.AutoSize = true;
            this.lnkBackToLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Underline);
            this.lnkBackToLogin.ForeColor = System.Drawing.Color.Blue;
            this.lnkBackToLogin.Location = new System.Drawing.Point(218, 471);
            this.lnkBackToLogin.Name = "lnkBackToLogin";
            this.lnkBackToLogin.Size = new System.Drawing.Size(198, 25);
            this.lnkBackToLogin.TabIndex = 8;
            this.lnkBackToLogin.Text = "← Quay lại đăng nhập";
            this.lnkBackToLogin.Click += new System.EventHandler(this.lnkBackToLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email";
            // 
            // txtRegEmail
            // 
            this.txtRegEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRegEmail.Location = new System.Drawing.Point(65, 194);
            this.txtRegEmail.Name = "txtRegEmail";
            this.txtRegEmail.Size = new System.Drawing.Size(330, 37);
            this.txtRegEmail.TabIndex = 11;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 528);
            this.Controls.Add(this.txtRegEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkBackToLogin);
            this.Controls.Add(this.btnDoRegister);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtRegPassword);
            this.Controls.Add(this.txtRegUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnDoRegister;
        private System.Windows.Forms.Label lnkBackToLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegEmail;
    }
}