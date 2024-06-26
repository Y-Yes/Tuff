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
        private char nextLetter; // New field to store the next letter
        private int score;
        private readonly Random random = new Random();
        private readonly char[] letters = "abcdfghijklmnopqrstuvwxyz".ToCharArray();
        private System.Windows.Forms.Timer timer;
        private int timeLeft;
        private PictureBox pictureBox1;
        private PictureBox nextLetterPictureBox; // New PictureBox for displaying the next letter
        private Label scoreLabel;
        private Label timeLabel;
        private Label pauseLabel;
        private bool gamePaused = false;
        private Label totalTimerLabel;
        private int totalTimeLeft = 60000;

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
            timer.Interval = 100; // Fire the event every 100 milliseconds
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start(); // Start the timer when the game loads
            timeLeft = 1000; // 1000 milliseconds (1 second) for each letter
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (totalTimeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Game Over! Your final score is: " + score);
                return; // Stop further processing once the game is over
            }

            totalTimeLeft -= timer.Interval; // Reduce the total time left by the timer interval
            totalTimerLabel.Text = "Total Time Left: " + (totalTimeLeft / 1000) + "s"; // Update the label to show remaining seconds

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
                timer.Start(); // Restart the timer for the next letter after updating
            }
        }

        private void GenerateRandomLetter()
        {
            currentLetter = nextLetter; // Set the current letter to the previously generated next letter
            nextLetter = letters[random.Next(letters.Length)]; // Generate a new next letter

            UpdatePictureBox();
            UpdateNextLetterPictureBox(); // Update the next letter PictureBox
            timeLeft = 1000; // Reset time left for each letter
            timeLabel.Text = $"Time Left: {timeLeft}ms";
            timer.Start();
        }

        private void UpdatePictureBox()
        {
            string resourceName = $"WinFormsApp1.Resources.{GetImageFileName(currentLetter)}";
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

        private void UpdateNextLetterPictureBox()
        {
            using (Bitmap bitmap = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.LightGray);
                    using (Font font = new Font("Arial", 48))
                    {
                        g.DrawString(nextLetter.ToString(), font, Brushes.Black, new PointF(10, 10));
                    }
                }
                nextLetterPictureBox.Image?.Dispose();
                nextLetterPictureBox.Image = (Bitmap)bitmap.Clone();
            }
        }

        private string GetImageFileName(char letter)
        {
            return $"{letter}.png";
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

        private Button nextTreeButton; // Declare the button at the class level

        private void BackButton()
        {
            // Existing component initializations...

            nextTreeButton = new Button
            {
                Text = "Next Tree",
                Location = new Point(12, 225), // Position below the pause label
                Size = new Size(100, 50),
                Font = new Font("Arial", 12)
            };
            nextTreeButton.Click += new EventHandler(NextTreeButton_Click); // Event handler for the button click
            this.Controls.Add(nextTreeButton);
        }

        private void NextTreeButton_Click(object sender, EventArgs e)
        {
           
            this.Hide(); // Hide the current form
            var gameForm = new Game(); // Assume Game is another form in your project
            totalTimeLeft = 0;
            gameForm.Closed += (s, args) => this.Close(); // Close the Level form when Game form is closed
            gameForm.Show(); // Show the Game form
        }

        private void UpdateTreeState()
        {
            int newTreeState = currentTreeState;

            if (score < 10+currentTree*5)
            {
                newTreeState = 1;
            }
            else if (score >= 10 + currentTree*5 && score < 25 + currentTree*5)
            {
                newTreeState = 2;
            }
            else if (score >= 25 + currentTree * 5)
            {
                newTreeState = 3;
            }

            if (newTreeState != currentTreeState)
            {
                currentTreeState = newTreeState;
                LoadImage(); // Reload the image for the new tree state
                InitializeComponent();
                InitializeTypingGameComponents();
                BackButton();
            }
        }



        private void InitializeTypingGameComponents()
        {
            totalTimerLabel = new Label
            {
                AutoSize = true,
                Location = new Point(12, 210),
                Name = "totalTimerLabel",
                Size = new Size(200, 13),
                TabIndex = 4,
                Text = "Total Time Left: 60s",
                Font = new Font("Arial", 12)
            };

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

            nextLetterPictureBox = new PictureBox
            {
                Location = new System.Drawing.Point(140, 10), // Position it in the top left corner
                Name = "nextLetterPictureBox",
                Size = new System.Drawing.Size(100, 100),
                TabIndex = 4,
                TabStop = false,
                BorderStyle = BorderStyle.FixedSingle // Add a border to make it look like a box
            };

            this.Controls.Add(totalTimerLabel);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(scoreLabel);
            this.Controls.Add(timeLabel);
            this.Controls.Add(pauseLabel);
            this.Controls.Add(nextLetterPictureBox); // Add the next letter PictureBox
        }
    }
}
