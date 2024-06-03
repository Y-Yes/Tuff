using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            LevelSelector();
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing); //On exit close the application
            this.Activated += new EventHandler(UpdateScore); //runs score update when unhiding the menu

        }
        private void buttonExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Closes the application
        }


        private void LevelSelector()
        {
            pictureBox1.Click += (sender, e) => OpenTree(1);
            pictureBox2.Click += (sender, e) => OpenTree(2);
            pictureBox3.Click += (sender, e) => OpenTree(3);
            pictureBox4.Click += (sender, e) => OpenTree(4);
            pictureBox5.Click += (sender, e) => OpenTree(5);
            pictureBox6.Click += (sender, e) => OpenTree(6);
        }
        private void OpenTree(int level) //Opens the new window with a tree passing in the selected level
        {
            this.Hide();//Hides level selector
            Level LevelForm = new Level(level);//Open the tree window with level number
            LevelForm.Show();
            LevelForm.FormClosed += (s, args) => this.Show(); //Unhides the level selector if you exit the level
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateScore(object sender, EventArgs e)
        {
            label4.Text = $"Score: {BigData.Score1}"; //Updates the all level scores
            label5.Text = $"Score: {BigData.Score2}";
            label6.Text = $"Score: {BigData.Score3}";
            label10.Text = $"Score: {BigData.Score4}";
            label11.Text = $"Score: {BigData.Score5}";
            label12.Text = $"Score: {BigData.Score6}";
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
