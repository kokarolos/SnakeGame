﻿
namespace SnakeGame
{
    public class Settings
    {
        private int gameSpeed = 50;
        private int gameWidth = 650;
        private int gameHeigth = 559;
        public Settings(){}

        public int GameSpeed()
        {
            return gameSpeed;
        }

        public int GameWidth()
        {
            return gameWidth;
        }

        public int GameHeigth()
        {
            return gameHeigth;
        }

    }
}
