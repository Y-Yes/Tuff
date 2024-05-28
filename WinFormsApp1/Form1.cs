using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path to the program you want to open
            string programPath = @"C:\Path\To\Your\Program.exe";

            try
            {
                // Start the program
                Process.Start(programPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to open the program: {ex.Message}");
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (checkBoxTerms.Checked)
            {
                Game gameForm = new Game();
                gameForm.Show();
                this.Hide(); // Hide the main form when Play is clicked
            }
            else
            {
                MessageBox.Show("You must accept the terms and conditions to play.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxTerms_CheckedChanged(object sender, EventArgs e)
        {
            // Additional logic for checkbox state change can be added here
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization logic when the form loads can be added here
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }


}
