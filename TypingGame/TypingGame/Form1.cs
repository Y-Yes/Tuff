using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TypingGame
{
    public partial class Form1 : Form
    {
        private char currentLetter;
        private int score;
        private readonly Random random = new Random();
        private readonly char[] letters = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';' };

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // To capture key presses
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            GenerateRandomLetter();
        }

        private void GenerateRandomLetter()
        {
            currentLetter = letters[random.Next(letters.Length)];
            UpdatePictureBox();
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
            if (e.KeyChar == currentLetter)
            {
                score++;
            }
            else
            {
                score--;
            }
            scoreLabel.Text = $"Score: {score}";
            GenerateRandomLetter();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            score = 0;
            scoreLabel.Text = $"Score: {score}";
            GenerateRandomLetter();
        }
    }
}
