namespace NT106_GROUP10
{
    partial class LoginForm
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.txtPassword = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtUsername = new ReaLTaiizor.Controls.CyberTextBox();
            this.btnRegister = new ReaLTaiizor.Controls.ParrotButton();
            this.btnLogin = new ReaLTaiizor.Controls.ParrotButton();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.btnRegister);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblForgotPassword);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblSubtitle);
            this.pnlLogin.Controls.Add(this.lblTitle);
            this.pnlLogin.Location = new System.Drawing.Point(270, 104);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(573, 549);
            this.pnlLogin.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Alpha = 20;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Background_WidthPen = 3F;
            this.txtPassword.BackgroundPen = true;
            this.txtPassword.ColorBackground = System.Drawing.Color.White;
            this.txtPassword.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtPassword.ColorLighting = System.Drawing.Color.White;
            this.txtPassword.ColorPen_1 = System.Drawing.Color.Black;
            this.txtPassword.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtPassword.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtPassword.Lighting = false;
            this.txtPassword.LinearGradientPen = false;
            this.txtPassword.Location = new System.Drawing.Point(62, 290);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.PenWidth = 15;
            this.txtPassword.RGB = false;
            this.txtPassword.Rounding = true;
            this.txtPassword.RoundingInt = 60;
            this.txtPassword.Size = new System.Drawing.Size(438, 47);
            this.txtPassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Tag = "Cyber";
            this.txtPassword.TextButton = "";
            this.txtPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtPassword.Timer_RGB = 300;
            // 
            // txtUsername
            // 
            this.txtUsername.Alpha = 20;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Background_WidthPen = 3F;
            this.txtUsername.BackgroundPen = true;
            this.txtUsername.ColorBackground = System.Drawing.Color.White;
            this.txtUsername.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtUsername.ColorLighting = System.Drawing.Color.White;
            this.txtUsername.ColorPen_1 = System.Drawing.Color.Black;
            this.txtUsername.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtUsername.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtUsername.Font = new System.Drawing.Font("Arial", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtUsername.Lighting = false;
            this.txtUsername.LinearGradientPen = false;
            this.txtUsername.Location = new System.Drawing.Point(62, 200);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PenWidth = 15;
            this.txtUsername.RGB = false;
            this.txtUsername.Rounding = true;
            this.txtUsername.RoundingInt = 60;
            this.txtUsername.Size = new System.Drawing.Size(438, 47);
            this.txtUsername.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtUsername.TabIndex = 12;
            this.txtUsername.Tag = "Cyber";
            this.txtUsername.TextButton = "";
            this.txtUsername.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtUsername.Timer_RGB = 300;
            // 
            // btnRegister
            // 
            this.btnRegister.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnRegister.ButtonImage = null;
            this.btnRegister.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnRegister.ButtonText = "Đăng ký tài khoản";
            this.btnRegister.ClickBackColor = System.Drawing.Color.DimGray;
            this.btnRegister.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnRegister.CornerRadius = 16;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnRegister.HoverBackgroundColor = System.Drawing.Color.DarkGray;
            this.btnRegister.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnRegister.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnRegister.Location = new System.Drawing.Point(62, 423);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(438, 45);
            this.btnRegister.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnRegister.TabIndex = 11;
            this.btnRegister.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnRegister.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnRegister.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnLogin.ButtonImage = null;
            this.btnLogin.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnLogin.ButtonText = "Đăng nhập";
            this.btnLogin.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(106)))));
            this.btnLogin.ClickTextColor = System.Drawing.Color.DimGray;
            this.btnLogin.CornerRadius = 16;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnLogin.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(70)))), ((int)(((byte)(153)))));
            this.btnLogin.HoverTextColor = System.Drawing.Color.White;
            this.btnLogin.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnLogin.Location = new System.Drawing.Point(62, 372);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(438, 45);
            this.btnLogin.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLogin.TabIndex = 10;
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLogin.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblForgotPassword.Location = new System.Drawing.Point(366, 471);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(140, 44);
            this.lblForgotPassword.TabIndex = 8;
            this.lblForgotPassword.Text = "Quên mật khẩu?";
            this.lblForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblUsername.Location = new System.Drawing.Point(68, 162);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(438, 35);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Tên đăng nhập";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblPassword.Location = new System.Drawing.Point(68, 262);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(420, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(97, 101);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(383, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Chào mừng bạn quay trở lại!";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.lblTitle.Location = new System.Drawing.Point(181, 42);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHAT APP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = global::NT106_GROUP10.Properties.Resources.BackgroundLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1110, 746);
            this.Controls.Add(this.pnlLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Chat App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblForgotPassword;
        private ReaLTaiizor.Controls.ParrotButton btnLogin;
        private ReaLTaiizor.Controls.ParrotButton btnRegister;
        private ReaLTaiizor.Controls.CyberTextBox txtUsername;
        private ReaLTaiizor.Controls.CyberTextBox txtPassword;
    }
}

