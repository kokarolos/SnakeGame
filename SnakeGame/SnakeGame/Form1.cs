using System;
using System.Windows.Forms;
using System.Linq;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Snake snake = new Snake();
        Berry berry = new Berry();
        Settings settings = new Settings();


        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer1.Interval=(1000/settings.GameSpeed());
            timer1.Tick += timer1_Tick;
            timer1.Start();
            berry.circles.Add(berry);
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void pictureBox1_Click(object sender, EventArgs e){}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            snake.Draw(e);
            berry.Draw(e);
            if(CheckForCollision())
            {
                snake.Eat();
                berry.GenerateNewBerries();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            snake.Move(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snake.OnSnakeMovement();
            snake.Die();
            pictureBox1.Invalidate();
        }
        public bool CheckForCollision() => (Math.Abs(berry.circles.First().CenterX - snake.SnakeParts[0].X) < 15.0f && Math.Abs(berry.circles.First().CenterY - snake.SnakeParts[0].Y) < 15.0f);

    }
}
