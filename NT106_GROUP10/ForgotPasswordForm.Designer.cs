namespace NT106_GROUP10
{
    partial class ForgotPasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.QuayLai = new System.Windows.Forms.Label();
            this.btnSendReset = new ReaLTaiizor.Controls.ParrotButton();
            this.txtRecoveryEmail = new ReaLTaiizor.Controls.CyberTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(50, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.label2.Location = new System.Drawing.Point(124, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "QUÊN MẬT KHẨU";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(50, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập email để nhận mã đặt lại mật khẩu";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.QuayLai);
            this.panel1.Controls.Add(this.btnSendReset);
            this.panel1.Controls.Add(this.txtRecoveryEmail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 354);
            this.panel1.TabIndex = 7;
            // 
            // QuayLai
            // 
            this.QuayLai.AutoSize = true;
            this.QuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuayLai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuayLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.QuayLai.Location = new System.Drawing.Point(255, 258);
            this.QuayLai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QuayLai.Name = "QuayLai";
            this.QuayLai.Size = new System.Drawing.Size(145, 19);
            this.QuayLai.TabIndex = 15;
            this.QuayLai.Text = "← Quay lại đăng nhập";
            this.QuayLai.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSendReset
            // 
            this.btnSendReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendReset.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.btnSendReset.ButtonImage = null;
            this.btnSendReset.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnSendReset.ButtonText = "Gửi mã khôi phục";
            this.btnSendReset.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(106)))));
            this.btnSendReset.ClickTextColor = System.Drawing.Color.DimGray;
            this.btnSendReset.CornerRadius = 16;
            this.btnSendReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendReset.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSendReset.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(70)))), ((int)(((byte)(153)))));
            this.btnSendReset.HoverTextColor = System.Drawing.Color.White;
            this.btnSendReset.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnSendReset.Location = new System.Drawing.Point(54, 218);
            this.btnSendReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendReset.Name = "btnSendReset";
            this.btnSendReset.Size = new System.Drawing.Size(336, 38);
            this.btnSendReset.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnSendReset.TabIndex = 14;
            this.btnSendReset.TextColor = System.Drawing.Color.White;
            this.btnSendReset.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnSendReset.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSendReset.Click += new System.EventHandler(this.btnSendReset_Click);
            // 
            // txtRecoveryEmail
            // 
            this.txtRecoveryEmail.Alpha = 20;
            this.txtRecoveryEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtRecoveryEmail.Background_WidthPen = 3F;
            this.txtRecoveryEmail.BackgroundPen = true;
            this.txtRecoveryEmail.ColorBackground = System.Drawing.Color.White;
            this.txtRecoveryEmail.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRecoveryEmail.ColorLighting = System.Drawing.Color.White;
            this.txtRecoveryEmail.ColorPen_1 = System.Drawing.Color.Black;
            this.txtRecoveryEmail.ColorPen_2 = System.Drawing.Color.IndianRed;
            this.txtRecoveryEmail.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtRecoveryEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRecoveryEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(246)))));
            this.txtRecoveryEmail.Lighting = false;
            this.txtRecoveryEmail.LinearGradientPen = false;
            this.txtRecoveryEmail.Location = new System.Drawing.Point(54, 175);
            this.txtRecoveryEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRecoveryEmail.Name = "txtRecoveryEmail";
            this.txtRecoveryEmail.PenWidth = 15;
            this.txtRecoveryEmail.RGB = false;
            this.txtRecoveryEmail.Rounding = true;
            this.txtRecoveryEmail.RoundingInt = 60;
            this.txtRecoveryEmail.Size = new System.Drawing.Size(336, 38);
            this.txtRecoveryEmail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtRecoveryEmail.TabIndex = 13;
            this.txtRecoveryEmail.Tag = "Cyber";
            this.txtRecoveryEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRecoveryEmail.TextButton = "";
            this.txtRecoveryEmail.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtRecoveryEmail.Timer_RGB = 300;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::NT106_GROUP10.Properties.Resources.BackgroundLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(538, 417);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.CyberTextBox txtRecoveryEmail;
        private ReaLTaiizor.Controls.ParrotButton btnSendReset;
        private System.Windows.Forms.Label QuayLai;
    }
}