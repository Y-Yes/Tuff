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
        private Dictionary<(int, int), Image> treeImages; // Dictionary that links the images to numbers

        // Stuff for typing game
        private char currentLetter;
        private int score;
        private readonly Random random = new Random();
        private readonly char[] letters = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';' };
        private System.Windows.Forms.Timer timer;
        private int timeLeft;
        private PictureBox pictureBox1;
        private Label scoreLabel;
        private Label timeLabel;
        private Label pauseLabel;
        private bool gamePaused = false;

        public Level(int tree)
        {
            InitializeComponent();
            currentTree = tree; // Uses the tree that user selected in the level selector
            currentTreeState = 1; // Selects the first stage of the tree

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
                {(3, 3), Properties.Resources.Sakura_3r},
                {(4, 1), Properties.Resources.Medis_krc_1r},
                {(4, 2), Properties.Resources.Medis_krc_2r},
                {(4, 3), Properties.Resources.Medis_krc_3r},
                {(5, 1), Properties.Resources.Palme_1r},
                {(5, 2), Properties.Resources.Palme_2r},
                {(5, 3), Properties.Resources.Palme_3r},
                {(6, 1), Properties.Resources.Pusis_1r},
                {(6, 2), Properties.Resources.Pusis_2r},
                {(6, 3), Properties.Resources.Pusis_3r}
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

                // Calculates where to place the image based on the picture size to be in the middle
                int centerX = ((this.ClientSize.Width - treePictureBox.Width) / 2) + 100;
                int bottomY = (this.ClientSize.Height - treePictureBox.Height) - 10;

                // Changes the location of the image
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
            timer.Interval = 100; // 100 milliseconds
            timer.Tick += new EventHandler(Timer_Tick);
            timeLeft = 1000; // 1000 milliseconds (1 second)
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 100;
                timeLabel.Text = $"Time Left: {timeLeft}ms";
            }
            else
            {
                timer.Stop();
                score--;
                UpdateTreeState();
                scoreLabel.Text = $"Score: {score}";
                GenerateRandomLetter();
            }
        }

        private void GenerateRandomLetter()
        {
            currentLetter = letters[random.Next(letters.Length)];
            UpdatePictureBox();
            timeLeft = 1000; // Reset time left for each letter
            timeLabel.Text = $"Time Left: {timeLeft}ms";
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

            // Update BigData based on the current tree
            switch (currentTree)
            {
                case 1: BigData.Score1 = score; break;
                case 2: BigData.Score2 = score; break;
                case 3: BigData.Score3 = score; break;
                case 4: BigData.Score4 = score; break;
                case 5: BigData.Score5 = score; break;
                case 6: BigData.Score6 = score; break;
            }

            UpdateTreeState();
            scoreLabel.Text = $"Score: {score}";
            GenerateRandomLetter();
        }

        private void UpdateTreeState()
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

            if (newTreeState != currentTreeState)
            {
                currentTreeState = newTreeState;
                LoadImage();
                InitializeComponent();
                InitializeTypingGameComponents();
            }
        }

        private void InitializeTypingGameComponents()
        {
            pictureBox1 = new PictureBox
            {
                Location = new System.Drawing.Point(12, 12),
                Name = "pictureBox1",
                Size = new System.Drawing.Size(100, 100),
                TabIndex = 0,
                TabStop = false
            };

            scoreLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(12, 115),
                Name = "scoreLabel",
                Size = new System.Drawing.Size(47, 13),
                TabIndex = 1,
                Text = "Score: 0",
                Font = new Font("Arial", 24)
            };

            timeLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(12, 150),
                Name = "timeLabel",
                Size = new System.Drawing.Size(120, 13),
                TabIndex = 2,
                Text = "Time Left: 1000ms",
                Font = new Font("Arial", 16)
            };

            pauseLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(12, 190),
                Name = "pauseLabel",
                Size = new System.Drawing.Size(200, 13),
                TabIndex = 3,
                Text = "Pause the game by pressing 'e'",
                Font = new Font("Arial", 12)
            };

            this.Controls.Add(pictureBox1);
            this.Controls.Add(scoreLabel);
            this.Controls.Add(timeLabel);
            this.Controls.Add(pauseLabel);
        }
    }
}
