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
            buttonPlay = new Button();
            checkBoxTerms = new CheckBox();
            labelTitle = new Label();
            panelMain = new Panel();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.FromArgb(220, 53, 69);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonExit.ForeColor = Color.White;
            buttonExit.Location = new Point(122, 250);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(100, 50);
            buttonExit.TabIndex = 0;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.BackColor = Color.FromArgb(40, 167, 69);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPlay.ForeColor = Color.White;
            buttonPlay.Location = new Point(481, 250);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(100, 50);
            buttonPlay.TabIndex = 1;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // checkBoxTerms
            // 
            checkBoxTerms.AutoSize = true;
            checkBoxTerms.Font = new Font("Segoe UI", 10F);
            checkBoxTerms.ForeColor = Color.White;
            checkBoxTerms.Location = new Point(200, 200);
            checkBoxTerms.Name = "checkBoxTerms";
            checkBoxTerms.Size = new Size(348, 23);
            checkBoxTerms.TabIndex = 2;
            checkBoxTerms.Text = "I accept the terms and conditions and privacy policy.";
            checkBoxTerms.UseVisualStyleBackColor = true;
            checkBoxTerms.CheckedChanged += checkBoxTerms_CheckedChanged;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(213, 75);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(278, 45);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Welcome to Tuff!";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(30, 30, 30);
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(labelTitle);
            panelMain.Controls.Add(checkBoxTerms);
            panelMain.Controls.Add(buttonPlay);
            panelMain.Controls.Add(buttonExit);
            panelMain.Location = new Point(50, 50);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(700, 350);
            panelMain.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Game Launcher";
            Load += Form1_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxTerms;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
    }
}
