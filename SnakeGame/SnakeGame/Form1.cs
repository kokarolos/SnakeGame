using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Snake snake = new Snake();
        Berry berry = new Berry();
        Circle circle = new Circle();
        Settings settings = new Settings();


        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer1.Interval=(1000/settings.GameSpeed());
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            snake.Draw(e);
            berry.Draw(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            snake.Move(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            snake.OnSnakeMovement();
            snake.CheckForCollision();
            snake.Die();
            pictureBox1.Invalidate();
        }
       
    }
}
