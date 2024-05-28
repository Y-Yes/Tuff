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
            pictureBox2 = new PictureBox();
            buttonPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.FromArgb(220, 53, 69);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonExit.ForeColor = Color.White;
            buttonExit.Location = new Point(390, 375);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(100, 34);
            buttonExit.TabIndex = 0;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // checkBoxTerms
            // 
            checkBoxTerms.AutoSize = true;
            checkBoxTerms.BackColor = Color.OliveDrab;
            checkBoxTerms.Font = new Font("Segoe UI", 10F);
            checkBoxTerms.ForeColor = Color.White;
            checkBoxTerms.Location = new Point(219, 415);
            checkBoxTerms.Name = "checkBoxTerms";
            checkBoxTerms.Size = new Size(348, 23);
            checkBoxTerms.TabIndex = 2;
            checkBoxTerms.Text = "I accept the terms and conditions and privacy policy.";
            checkBoxTerms.UseVisualStyleBackColor = false;
            checkBoxTerms.CheckedChanged += checkBoxTerms_CheckedChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.tuff;
            pictureBox2.Location = new Point(-2, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(803, 449);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.BackColor = Color.FromArgb(40, 167, 69);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPlay.ForeColor = Color.White;
            buttonPlay.Location = new Point(284, 375);
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
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBoxTerms);
            Controls.Add(buttonPlay);
            Controls.Add(buttonExit);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Game Launcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxTerms;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button buttonPlay;
    }
}
