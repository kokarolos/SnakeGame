using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Snake
    {

        private readonly float startingPosX = 300.0f;
        private readonly float startingPosY = 200.0f;
        private readonly int rectHeigth = 16;
        private readonly int rectWidth = 16;
        private bool keyUp;
        private bool keyDown;
        private bool keyLeft;
        private bool keyRight;
        public bool berryIsEaten;
        private float updatedSnakeX;
        private float updatedSnakeY;

        Settings settings = new Settings();
        private List<Rectangle> SnakeParts = new List<Rectangle>();
        Circle list = new Berry();

        public Snake()
        {
            SnakeParts.Add(new Rectangle((int)startingPosX,(int)startingPosY,rectWidth,rectHeigth));
        }

        public static bool GetBerryCondition()
        {
            bool berryisEaten = true;
            return berryisEaten;
        }

        //responsive for Snake movement
        public void OnSnakeMovement()
        {

            for(int i = SnakeParts.Count-1; i>=0; i--)
            {
                if (i == 0)
                {
                    if (keyUp == true)
                    {
                        Rectangle temp = SnakeParts[0];
                        temp.Y -= 10;
                        SnakeParts[0] = temp;
                        updatedSnakeY = temp.Y;
                    }
                    if (keyDown == true)
                    {
                        Rectangle temp = SnakeParts[0];
                        temp.Y += 10;
                        SnakeParts[0] = temp;
                        updatedSnakeY = temp.Y;
                    }
                    if (keyRight == true)
                    {
                        Rectangle temp = SnakeParts[0];
                        temp.X += 10;
                        SnakeParts[0] = temp;
                        updatedSnakeX = temp.X;
                    }
                    if (keyLeft == true)
                    {
                        Rectangle temp = SnakeParts[0];
                        temp.X -= 10;
                        SnakeParts[0] = temp;
                        updatedSnakeX = temp.X;
                    }
                }
                else
                {
                    SnakeParts[i] = SnakeParts[i - 1];

                }
            }
        }

        //checks if snakehead exceeds game borders , or for collision with its body
        public  void Die()
        {
            int i;
            if (SnakeParts[0].X > settings.GameWidth() || SnakeParts[0].Y > settings.GameHeigth() || SnakeParts[0].X < 0 || SnakeParts[0].Y < 0 )
            {                        
               SnakeParts.RemoveRange(1, SnakeParts.Count - 1);
            }
            for(i=1; i<SnakeParts.Count;i++)
            {
               if(SnakeParts[0].X == SnakeParts[i].X && SnakeParts[0].Y == SnakeParts[i].Y)
               {
                    SnakeParts.RemoveRange(1, SnakeParts.Count - 1);
               }
            }
        }

        // checks the collision with berries
        public void CheckForCollision()
        {
            if (Math.Abs(list.GetCenterX() - SnakeParts[0].X) < 10.0f && Math.Abs(list.GetCenterY() - SnakeParts[0].Y) < 10.0f) 
            {
                GetBerryCondition();
                Eat();
            }
        }

        private void Eat()
        {
           SnakeParts.Add(new Rectangle((int)updatedSnakeX, (int)updatedSnakeY+10, rectWidth, rectHeigth));
           //SnakeParts.Insert(0, new Rectangle((int)updatedSnakesX, (int)updatedSnakesY, rectWidth, rectHeigth));
        }

        //stores keys into booleans
        public void Move(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                keyUp = true;
                keyDown = false;
                keyLeft = false;
                keyRight = false;
            }
            if (e.KeyData == Keys.Down)
            {
                keyDown = true;
                keyUp = false;
                keyLeft = false;
                keyRight = false;
            }
            if (e.KeyData == Keys.Right)
            {
                keyRight = true;
                keyDown = false;
                keyLeft = false;
                keyUp = false;
            }
            if (e.KeyData == Keys.Left)
            {
                keyLeft = true;
                keyDown = false;
                keyUp = false;
                keyRight = false;
            }
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var snakePart in SnakeParts)
            {
                Graphics g = e.Graphics;
                SolidBrush b = new SolidBrush(Color.Violet);
                g.FillRectangle(b, snakePart);
            }
        }

    }

}



