using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Circle
    {
        private readonly float Radius = 5f;
        private float centerX=15 ;
        private float centerY=15 ;
        public Circle()
        {

        }
     

        public Circle(float CenterX, float CenterY, float radius)
        {
            this.centerX = CenterX;
            this.centerY = CenterY;
            this.Radius = radius;
        }

        public float GetCenterX()
        {
            return centerX;
        }

        public float GetCenterY()
        {
            return centerY;
        }

        public float GetRadius()
        {
            return Radius;
        }

        public  void Draw(PaintEventArgs e)
        { 
                Graphics g = e.Graphics;
                Pen p = new Pen(Color.Gray);
                SolidBrush b = new SolidBrush(Color.Green);
                g.DrawEllipse(p, centerX - Radius, centerY - Radius, Radius + Radius, Radius + Radius);
                g.FillEllipse(b,  centerX - Radius, centerY - Radius, Radius + Radius, Radius + Radius);
        }

    }
}

