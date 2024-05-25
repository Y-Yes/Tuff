using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class Level : Form
    {
        private int currentTree;
        private int currentTreeState;
        private SoundPlayer _soundPlayer;
        private Dictionary<(int, int), Image> treeImages; //God that links the images to numbers
        public Level(int tree)
        {
            InitializeComponent();
            currentTree = tree; //uses the tree that user selected in the level selector
            currentTreeState = 1; //selects the first stage of the tree

            treeImages = new Dictionary<(int, int), Image>
            {
                {(1, 1), Properties.Resources.Normal_1r},
                {(1, 2), Properties.Resources.Normal_2r},
                {(1, 3), Properties.Resources.Normal_3r},
                {(2, 1), Properties.Resources.Bamboo_1r},
                {(2, 2), Properties.Resources.Bamboo_2r},
                {(2, 3), Properties.Resources.Bamboo_3r},
                {(3, 1), Properties.Resources.Sakura_1r},
                {(3, 2), Properties.Resources.Sakura_2r},
                {(3, 3), Properties.Resources.Sakura_3r}
            };
            LoadImage();
        }
        private void LoadImage()
        {
            if(treeImages.TryGetValue((currentTree, currentTreeState), out Image currentImage))
            {
                // Creates the picturebox
                PictureBox treePictureBox = new PictureBox
                {
                    Image = currentImage,
                    SizeMode = PictureBoxSizeMode.AutoSize 
                };

                // Adds the picturebox to the window
                this.Controls.Add(treePictureBox);

                // calculates where to place the image based on the picture size to be in the middle
                int centerX = (this.ClientSize.Width - treePictureBox.Width) / 2;
                int bottomY = (this.ClientSize.Height - treePictureBox.Height)-50;

                // changes the location of the image
                treePictureBox.Location = new Point(centerX, bottomY);
                this.Controls.Clear();
                this.Controls.Add(treePictureBox);
                //adds a button for growing the tree
                Button growButton = new Button { Text = "GrowLeTree", Location = new Point(10, 420) };
                growButton.Click += GrowButton_Click;
                this.Controls.Add(growButton);
                InitializeComponent();
                //_soundPlayer = new SoundPlayer("amogus.wav");
            }
        }
        private void GrowButton_Click(object sender, EventArgs e) //cycles through tree states
        {
            
            if (BigData.Score1 == 4)
            {
                currentTreeState++;
            }
            if (BigData.Score1 == 9)
            {
                currentTreeState++;
            }


            if (BigData.Score2 == 4)
            {
                currentTreeState++;
            }
            if (BigData.Score2 == 9)
            {
                currentTreeState++;
            }

            if (BigData.Score3 == 4)
            {
                currentTreeState++;
            }
            if (BigData.Score3 == 9)
            {
                currentTreeState++;
            }


            if (currentTree == 1)//Updates each levels score in the menu when pressing grow
            {
                BigData.Score1 += 1;
            }
            if (currentTree == 2)
            {
                BigData.Score2 += 1;
            }
            if (currentTree == 3)
            {
                BigData.Score3 += 1;
            }
            if (currentTreeState > 3) currentTreeState = 1;
            LoadImage();
            InitializeComponent();
            //_soundPlayer = new SoundPlayer("C:\\Users\\Maka\\source\\repos\\Tuff\\WinFormsApp1\\Resources\\amogus.wav"); // JEI NEVEIKIA TRINKIT 119 ir 120 EILUTES NAHUI!!!!! BIG WARNIGN BIG WARNING BIG WARNIGN
            //_soundPlayer.Play();
        }
    }
}
