using System;
using System.Collections.Generic;
using System.Text;


namespace Snake
{
    enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    enum Turn
    { //U up, D down, R right, L left, O or
        UD = 0,
        RL = 1,
        DROLU = 2,
        RUODL = 3,
        UROLD = 4,
        ULORD = 5
    }
    class Snake
    {
        readonly string head_sign = "▲▼►◄";
        readonly string body_sign = "┃━┗┛┏┓";//В новой версии будут и другие знаки
        Turn Turn { get; set; }
        int ww, wh;
        public Place head;
        public List<Place> body = new List<Place>(100);
        public bool eat = false;
        Direction go;
        public Direction Go
        {
            get { return go; }
            set { go = value; }
        }
        public Direction Last_go { get;set; }
        public void Start()
        {
            Console.CursorVisible = false;
            ww = Console.WindowWidth;
            wh = Console.WindowHeight;
            ww--;
            head = new Place(ww / 2, wh / 2);
            body.Add(new Place(ww / 2, (wh / 2) + 1));
            body.Add(new Place(ww / 2, (wh / 2) + 2));
            Turn = Turn.UD;
            Console.SetCursorPosition(head.X, head.Y);
            Console.Write(head_sign[0]);
            Console.SetCursorPosition(body[0].X, body[0].Y);
            Console.Write(body_sign[0]);
            Console.SetCursorPosition(body[1].X, body[1].Y);
            Console.Write(body_sign[0]);
        }
        public void GetDirection(Direction dir)
        {
            go = dir;
        }
        public void MoveHead()
        {
            body.Insert(0, new Place(head.X, head.Y));
            MoveBody();
            switch (go)
            {
                case Direction.Up:
                    if (head.Y > 0) head.Y--;
                    else head.Y = wh - 1;
                    head.Y %= wh;
                    if (Last_go == go)
                        Show(0, 0);
                    else {
                        if (Last_go == Direction.Left)
                            Show(0, (int)Turn.DROLU);
                        if (Last_go == Direction.Right)
                            Show(0, (int)Turn.RUODL);
                    }
                    break;
                case Direction.Down:
                    head.Y++;
                    head.Y %= wh;
                    if (Last_go == go)
                        Show(1, 0);
                    else
                    {
                        if (Last_go == Direction.Left)
                            Show(1, (int)Turn.UROLD);
                        if (Last_go == Direction.Right)
                            Show(1, (int)Turn.ULORD);
                    }
                    break;
                case Direction.Right:
                    head.X++;
                    head.X %= ww;
                    if (Last_go == go)
                        Show(2, 1);
                    else
                    {
                        if (Last_go == Direction.Up)
                            Show(2, (int)Turn.UROLD);
                        if (Last_go == Direction.Down)
                            Show(2, (int)Turn.DROLU);
                    }
                    break;
                case Direction.Left:
                    if (head.X > 0) head.X--;
                    else head.X = ww - 1;
                    head.X %= ww;
                    if (Last_go == go)
                        Show(3, 1);
                    else
                    {
                        if (Last_go == Direction.Up)
                            Show(3, (int)Turn.ULORD);
                        if (Last_go == Direction.Down)
                            Show(3, (int)Turn.RUODL);
                    }
                    break;
            }

        }
        private void Show(int shead, int sbody)
        {

            Console.SetCursorPosition(head.X, head.Y);
            Console.Write(head_sign[shead]);
            Console.SetCursorPosition(body[0].X, body[0].Y);
            Console.Write(body_sign[sbody]);
            Console.SetCursorPosition(0, 0);
        }
        private void MoveBody()//Хочу узнать как выполнять эту функцию в отдельном потоке
        {
            if (!eat)
            {
                Console.SetCursorPosition(body[body.Count - 1].X, body[body.Count - 1].Y);
                Console.Write(" ");
                body.RemoveAt(body.Count - 1);
            }
            else
            {
                eat = false;
                
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(body.Count + 1);
        }
    }
}
