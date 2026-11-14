namespace NT106_GROUP10
{
    partial class ReelsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.Card.SuspendLayout();
            this.SuspendLayout();
            // 
            // Card
            // 
            this.Card.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Card.BackColor = System.Drawing.Color.White;
            this.Card.Controls.Add(this.label1);
            this.Card.Location = new System.Drawing.Point(131, 0);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(860, 803);
            this.Card.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reels";
            // 
            // ReelsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.Card);
            this.Name = "ReelsControl";
            this.Size = new System.Drawing.Size(1122, 803);
            this.Card.ResumeLayout(false);
            this.Card.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Card;
        private System.Windows.Forms.Label label1;
    }
}
