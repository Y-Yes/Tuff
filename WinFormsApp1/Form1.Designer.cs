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
            buttonExit = new Button();
            checkBoxTerms = new CheckBox();
            buttonPlay = new Button();
            SuspendLayout();
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.None;
            buttonExit.BackColor = Color.FromArgb(220, 53, 69);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonExit.ForeColor = Color.White;
            buttonExit.Location = new Point(552, 443);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(100, 34);
            buttonExit.TabIndex = 0;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // checkBoxTerms
            // 
            checkBoxTerms.Anchor = AnchorStyles.None;
            checkBoxTerms.AutoSize = true;
            checkBoxTerms.BackColor = Color.OliveDrab;
            checkBoxTerms.Font = new Font("Segoe UI", 10F);
            checkBoxTerms.ForeColor = Color.White;
            checkBoxTerms.Location = new Point(336, 502);
            checkBoxTerms.Name = "checkBoxTerms";
            checkBoxTerms.Size = new Size(348, 23);
            checkBoxTerms.TabIndex = 2;
            checkBoxTerms.Text = "I accept the terms and conditions and privacy policy.";
            checkBoxTerms.UseVisualStyleBackColor = false;
            checkBoxTerms.CheckedChanged += checkBoxTerms_CheckedChanged;
            // 
            // buttonPlay
            // 
            buttonPlay.Anchor = AnchorStyles.None;
            buttonPlay.BackColor = Color.FromArgb(40, 167, 69);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPlay.ForeColor = Color.White;
            buttonPlay.Location = new Point(367, 443);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(100, 34);
            buttonPlay.TabIndex = 1;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources._2120C9C9_C624_49E0_A235_EAED7E190102;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(986, 582);
            Controls.Add(checkBoxTerms);
            Controls.Add(buttonPlay);
            Controls.Add(buttonExit);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Game Launcher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxTerms;
        private PictureBox pictureBox1;
        private Button buttonPlay;
    }
}
