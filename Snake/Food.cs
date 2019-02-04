using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food
    {
        public bool Exist { get; set; }
        public Place Position { get; set;  }
        public void ThrowFood()
        {
            Position = new Place();
            Random rand = new Random();
            Position.X = rand.Next(Console.WindowWidth - 2);
            Position.Y = rand.Next(Console.WindowHeight - 1);
            bool x = true;
            while (x)
            {
                if(Position!=Game.snake.head && !Game.snake.body.Contains(Position))
                {
                    Console.SetCursorPosition(Position.X, Position.Y);
                    Console.Write("○");
                    x = false;
                    Exist = true;
                }
            }
        }
    }
}
