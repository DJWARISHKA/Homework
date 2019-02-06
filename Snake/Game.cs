using System;
using System.Threading;

namespace Snake 
{
    class Game
    {
        static bool dead = false;
        static Timer time;
        public static Snake snake;
        public static Food food;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            snake = new Snake();
            food = new Food();
            snake.Start();
            snake.GetDirection(Direction.Up);
            food.Exist = false;            
            char c = ' ';
            time = new Timer(Loop, null, 0, 100);
            while (c != 27)
            {
                snake.Last_go = snake.Go;
                c = (char)Console.ReadKey().Key;
                ChangeDirection(c);
            }
        }
        static void ChangeDirection(char c)
        {
            switch (c)
            {
                case (char)37:
                    if (snake.Go != Direction.Right)
                        snake.Go = Direction.Left;
                    break;
                case (char)39:
                    if (snake.Go != Direction.Left)
                        snake.Go = Direction.Right;
                    break;
                case (char)38:
                    if (snake.Go != Direction.Down)
                        snake.Go = Direction.Up;
                    break;
                case (char)40:
                    if (snake.Go != Direction.Up)
                        snake.Go = Direction.Down;
                    break;                    
            }
            //Loop(null);
        }
        static void Loop(object obj)
        {
            if (dead) return;
            if (!food.Exist)
                food.ThrowFood();
            if (snake.head.X == food.Position.X && snake.head.Y == food.Position.Y)
            {
                snake.eat = true;
                food.Exist = false;
            }
            for(int i = 0; i < snake.body.Count; i++)
            if (snake.body[i].X == snake.head.X && snake.body[i].Y == snake.head.Y)
            {
                    dead = true;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Score {snake.body.Count + 1}");
                    return;
            }
                snake.MoveHead();            
        }

    }
}
