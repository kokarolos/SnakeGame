using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Berry : Circle
    {
        public List<Circle> circles { get; set; } = new List<Circle>();

        public Berry()
            :base(MyRandom.GenerateRandom(), MyRandom.GenerateRandom(), 15,15)
        {
        }

        public override void Draw(PaintEventArgs e)
        {
            foreach(var obj in circles)
            {
                Graphics g = e.Graphics;
                SolidBrush d = new SolidBrush(Color.AliceBlue);
                Pen p = new Pen(Color.Gray);
                g.DrawEllipse(p, obj.CenterX, obj.CenterY, obj.Width, obj.Height);
                g.FillEllipse(d, obj.CenterX, obj.CenterY, obj.Width, obj.Height);
            }
        }

        public void GenerateNewBerries()
        {
           circles.Clear();
           circles.Add(new Berry());
        }
    }
}
