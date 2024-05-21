namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.checkBoxTerms = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Location = new System.Drawing.Point(511, 298);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Lime;
            this.buttonPlay.Location = new System.Drawing.Point(142, 298);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            
            // 
            // checkBoxTerms
            // 
            this.checkBoxTerms.AutoSize = true;
            this.checkBoxTerms.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            this.checkBoxTerms.Location = new System.Drawing.Point(230, 248);
            this.checkBoxTerms.Name = "checkBoxTerms";
            this.checkBoxTerms.Size = new System.Drawing.Size(302, 19);
            this.checkBoxTerms.TabIndex = 2;
            this.checkBoxTerms.Text = "Accept the terms and conditions and privacy policy?";
            this.checkBoxTerms.UseVisualStyleBackColor = false;
            this.checkBoxTerms.CheckedChanged += new System.EventHandler(this.CheckBoxTerms_CheckedChanged);
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.checkBoxTerms);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonExit);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxTerms;
    }
}
