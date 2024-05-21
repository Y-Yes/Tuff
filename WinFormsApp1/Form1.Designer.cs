namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(511, 298);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.Location = new Point(142, 298);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Play";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.ActiveCaption;
            checkBox1.Location = new Point(230, 248);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(302, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Accept the terms and conditions and privacy policy?";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(944, 681);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
    }
}
