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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lnkBackToLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoRegister = new ReaLTaiizor.Controls.ParrotButton();
            this.txtConfirmPassword = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtRegPassword = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtRegEmail = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtRegUsername = new ReaLTaiizor.Controls.CyberTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblTitle.Location = new System.Drawing.Point(123, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblUsername.Location = new System.Drawing.Point(88, 110);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(152, 28);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblPassword.Location = new System.Drawing.Point(88, 306);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 28);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(88, 404);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(194, 28);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // lnkBackToLogin
            // 
            this.lnkBackToLogin.AutoSize = true;
            this.lnkBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBackToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lnkBackToLogin.Location = new System.Drawing.Point(284, 570);
            this.lnkBackToLogin.Name = "lnkBackToLogin";
            this.lnkBackToLogin.Size = new System.Drawing.Size(180, 23);
            this.lnkBackToLogin.TabIndex = 8;
            this.lnkBackToLogin.Text = "← Quay lại đăng nhập";
            this.lnkBackToLogin.Click += new System.EventHandler(this.lnkBackToLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(88, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnDoRegister);
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.txtRegPassword);
            this.panel1.Controls.Add(this.txtRegEmail);
            this.panel1.Controls.Add(this.txtRegUsername);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lnkBackToLogin);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.lblConfirmPassword);
            this.panel1.Location = new System.Drawing.Point(118, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 613);
            this.panel1.TabIndex = 12;
            // 
            // btnDoRegister
            // 
            this.btnDoRegister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnDoRegister.ButtonImage = null;
            this.btnDoRegister.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnDoRegister.ButtonText = "Đăng ký tài khoản";
            this.btnDoRegister.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(106)))));
            this.btnDoRegister.ClickTextColor = System.Drawing.Color.DimGray;
            this.btnDoRegister.CornerRadius = 16;
            this.btnDoRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoRegister.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDoRegister.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(70)))), ((int)(((byte)(153)))));
            this.btnDoRegister.HoverTextColor = System.Drawing.Color.White;
            this.btnDoRegister.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnDoRegister.Location = new System.Drawing.Point(130, 514);
            this.btnDoRegister.Name = "btnDoRegister";
            this.btnDoRegister.Size = new System.Drawing.Size(295, 52);
            this.btnDoRegister.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDoRegister.TabIndex = 19;
            this.btnDoRegister.TextColor = System.Drawing.Color.White;
            this.btnDoRegister.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDoRegister.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDoRegister.Click += new System.EventHandler(this.btnDoRegister_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Alpha = 20;
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.Background_WidthPen = 3F;
            this.txtConfirmPassword.BackgroundPen = true;
            this.txtConfirmPassword.ColorBackground = System.Drawing.Color.White;
            this.txtConfirmPassword.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtConfirmPassword.ColorLighting = System.Drawing.Color.White;
            this.txtConfirmPassword.ColorPen_1 = System.Drawing.Color.Black;
            this.txtConfirmPassword.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtConfirmPassword.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 12F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtConfirmPassword.Lighting = false;
            this.txtConfirmPassword.LinearGradientPen = false;
            this.txtConfirmPassword.Location = new System.Drawing.Point(93, 437);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Password = true;
            this.txtConfirmPassword.PenWidth = 15;
            this.txtConfirmPassword.RGB = false;
            this.txtConfirmPassword.Rounding = true;
            this.txtConfirmPassword.RoundingInt = 60;
            this.txtConfirmPassword.Size = new System.Drawing.Size(371, 50);
            this.txtConfirmPassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtConfirmPassword.TabIndex = 18;
            this.txtConfirmPassword.Tag = "Cyber";
            this.txtConfirmPassword.TextButton = "";
            this.txtConfirmPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtConfirmPassword.Timer_RGB = 300;
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Alpha = 20;
            this.txtRegPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtRegPassword.Background_WidthPen = 3F;
            this.txtRegPassword.BackgroundPen = true;
            this.txtRegPassword.ColorBackground = System.Drawing.Color.White;
            this.txtRegPassword.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegPassword.ColorLighting = System.Drawing.Color.White;
            this.txtRegPassword.ColorPen_1 = System.Drawing.Color.Black;
            this.txtRegPassword.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtRegPassword.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtRegPassword.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRegPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegPassword.Lighting = false;
            this.txtRegPassword.LinearGradientPen = false;
            this.txtRegPassword.Location = new System.Drawing.Point(93, 339);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.Password = true;
            this.txtRegPassword.PenWidth = 15;
            this.txtRegPassword.RGB = false;
            this.txtRegPassword.Rounding = true;
            this.txtRegPassword.RoundingInt = 60;
            this.txtRegPassword.Size = new System.Drawing.Size(371, 50);
            this.txtRegPassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtRegPassword.TabIndex = 17;
            this.txtRegPassword.Tag = "Cyber";
            this.txtRegPassword.TextButton = "";
            this.txtRegPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtRegPassword.Timer_RGB = 300;
            // 
            // txtRegEmail
            // 
            this.txtRegEmail.Alpha = 20;
            this.txtRegEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtRegEmail.Background_WidthPen = 3F;
            this.txtRegEmail.BackgroundPen = true;
            this.txtRegEmail.ColorBackground = System.Drawing.Color.White;
            this.txtRegEmail.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegEmail.ColorLighting = System.Drawing.Color.White;
            this.txtRegEmail.ColorPen_1 = System.Drawing.Color.Black;
            this.txtRegEmail.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtRegEmail.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtRegEmail.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRegEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegEmail.Lighting = false;
            this.txtRegEmail.LinearGradientPen = false;
            this.txtRegEmail.Location = new System.Drawing.Point(93, 240);
            this.txtRegEmail.Name = "txtRegEmail";
            this.txtRegEmail.PenWidth = 15;
            this.txtRegEmail.RGB = false;
            this.txtRegEmail.Rounding = true;
            this.txtRegEmail.RoundingInt = 60;
            this.txtRegEmail.Size = new System.Drawing.Size(371, 50);
            this.txtRegEmail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtRegEmail.TabIndex = 16;
            this.txtRegEmail.Tag = "Cyber";
            this.txtRegEmail.TextButton = "";
            this.txtRegEmail.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtRegEmail.Timer_RGB = 300;
            // 
            // txtRegUsername
            // 
            this.txtRegUsername.Alpha = 20;
            this.txtRegUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtRegUsername.Background_WidthPen = 3F;
            this.txtRegUsername.BackgroundPen = true;
            this.txtRegUsername.ColorBackground = System.Drawing.Color.White;
            this.txtRegUsername.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegUsername.ColorLighting = System.Drawing.Color.White;
            this.txtRegUsername.ColorPen_1 = System.Drawing.Color.Black;
            this.txtRegUsername.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtRegUsername.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtRegUsername.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRegUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRegUsername.Lighting = false;
            this.txtRegUsername.LinearGradientPen = false;
            this.txtRegUsername.Location = new System.Drawing.Point(93, 143);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.PenWidth = 15;
            this.txtRegUsername.RGB = false;
            this.txtRegUsername.Rounding = true;
            this.txtRegUsername.RoundingInt = 60;
            this.txtRegUsername.Size = new System.Drawing.Size(371, 50);
            this.txtRegUsername.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtRegUsername.TabIndex = 15;
            this.txtRegUsername.Tag = "Cyber";
            this.txtRegUsername.TextButton = "";
            this.txtRegUsername.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtRegUsername.Timer_RGB = 300;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NT106_GROUP10.Properties.Resources.BackgroundLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(783, 671);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lnkBackToLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.CyberTextBox txtRegEmail;
        private ReaLTaiizor.Controls.CyberTextBox txtRegUsername;
        private ReaLTaiizor.Controls.CyberTextBox txtConfirmPassword;
        private ReaLTaiizor.Controls.CyberTextBox txtRegPassword;
        private ReaLTaiizor.Controls.ParrotButton btnDoRegister;
    }
}