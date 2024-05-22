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
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing); //On exit close the application
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Closes the application
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
