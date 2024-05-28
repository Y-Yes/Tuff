using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Level : Form
    {
        private int currentTree;
        private int currentTreeState;
        private Dictionary<(int, int), Image> treeImages; //God that links the images to numbers

        // stuff for typing game
        private char currentLetter;
        private int score;
        private readonly Random random = new Random();
        private readonly char[] letters = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';' };
        private System.Windows.Forms.Timer timer;
        private int timeLeft;
        private PictureBox pictureBox1;
        private Label scoreLabel;
        private Label pauseLabel;
        private bool gamePaused = false;

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
            LoadTypingGame();
        }

        private void LoadImage()
        {
            if (treeImages.TryGetValue((currentTree, currentTreeState), out Image currentImage))
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
                int centerX = ((this.ClientSize.Width - treePictureBox.Width) / 2) + 100;
                int bottomY = (this.ClientSize.Height - treePictureBox.Height) - 50;

                // changes the location of the image
                treePictureBox.Location = new Point(centerX, bottomY);
                this.Controls.Clear();
                this.Controls.Add(treePictureBox);
                InitializeComponent();
            }
        }



        private void LoadTypingGame()
        {
            this.KeyPreview = true; // To capture key presses
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            InitializeTimer();
            InitializeTypingGameComponents();
            GenerateRandomLetter(); // Start the game immediately
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer(); 
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(Timer_Tick);
            timeLeft = 1;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (timeLeft > 0)
            {
                timeLeft--;
            }
            else
            {
                timer.Stop();
                score--;
                scoreLabel.Text = $"Score: {score}";
                GenerateRandomLetter();
            }
        }

        private void GenerateRandomLetter()
        {
            currentLetter = letters[random.Next(letters.Length)];
            UpdatePictureBox();
            timeLeft = 1;
            timer.Start();
        }

        private void UpdatePictureBox()
        {
            string resourceName = $"TypingGame.Resources.{GetImageFileName(currentLetter)}";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromStream(stream);
                }
                else
                {
                    using (Bitmap bitmap = new Bitmap(100, 100))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.Clear(Color.White);
                            using (Font font = new Font("Arial", 48))
                            {
                                g.DrawString(currentLetter.ToString(), font, Brushes.Black, new PointF(10, 10));
                            }
                        }
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = (Bitmap)bitmap.Clone();
                    }
                }
            }
        }

        private string GetImageFileName(char letter)
        {
            return letter == ';' ? "semicolon.png" : $"{letter}.png";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'e')
            {
                if (gamePaused)
                {
                    timer.Start();
                    gamePaused = false;
                }
                else
                {
                    timer.Stop();
                    gamePaused = true;
                }
                return;
            }

            if (e.KeyChar == currentLetter)
            {
                score++;

                
            }
            else
            {
                score--;
            }
            if (currentTree == 1) //Updates each levels score in the menu when pressing grow
            {
                BigData.Score1 = score;
            }
            if (currentTree == 2)
            {
                BigData.Score2 = score;
            }
            if (currentTree == 3)
            {
                BigData.Score3 = score;
            }


            
            scoreLabel.Text = $"Score: {score}";
            UpdateTreeState();
            GenerateRandomLetter();

        }
        private void UpdateTreeState()// smart tree updating system to get rid of blinking
        {
            int newTreeState = currentTreeState;

            if (score < 4)
            {
                newTreeState = 1;
            }
            else if (score >= 4 && score < 9)
            {
                newTreeState = 2;
            }
            else if (score >= 9)
            {
                newTreeState = 3;
            }

            if (newTreeState != currentTreeState)//Only redraws the entire screen when the tree grows
            {
                currentTreeState = newTreeState;
                LoadImage();
                InitializeComponent();
                InitializeTypingGameComponents();
            }
        }


        private void InitializeTypingGameComponents()
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(100, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;

            scoreLabel = new Label();
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new System.Drawing.Point(12, 115);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new System.Drawing.Size(47, 13);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "Score: 0";
            scoreLabel.Font = new Font("Arial", 24);

            // pausing information
            pauseLabel = new Label();
            pauseLabel.AutoSize = true;
            pauseLabel.Location = new System.Drawing.Point(12, 160);
            pauseLabel.Name = "pauseInformation";
            pauseLabel.Size = new System.Drawing.Size(47, 13);
            pauseLabel.TabIndex = 1;
            pauseLabel.Text = "pause the game by pressing 'e' ";
            // loads the thingies
            this.Controls.Add(pictureBox1);
            this.Controls.Add(scoreLabel);
            this.Controls.Add(pauseLabel);
        }
    }
}
