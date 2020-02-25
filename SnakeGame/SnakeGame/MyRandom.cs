using System;

namespace SnakeGame
{
    public static class MyRandom
    {
        static Random r = new Random();
        public static int GenerateRandom()
        {
            var m_randNumber = r.Next(10, 500);
            return m_randNumber;
        }
    }
}
