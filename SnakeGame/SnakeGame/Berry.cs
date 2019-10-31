using System;


namespace SnakeGame
{

    public class Berry : Circle
    {
        public Berry()
            :base((float)GenerateRandomNumber(), (float)GenerateRandomNumber(), 4)
        {
            
        }

        private static int GenerateRandomNumber()
        {
            Random rad = new Random();
            var m_randNumber = rad.Next(10, 500);
            return m_randNumber;
        }
    }
}
