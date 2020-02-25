using System.Windows.Forms;

namespace SnakeGame
{
    abstract public class Circle
    {
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        protected Circle(float centerX, float centerY, float width, float height)
        {
            CenterX = centerX;
            CenterY = centerY;
            Width = width;
            Height = height;
        }

        public abstract void Draw(PaintEventArgs e);
    }
}

