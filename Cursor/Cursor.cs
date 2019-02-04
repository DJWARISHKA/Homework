using System;

namespace Cursor
{
    class Cursor
    {
        static void Main(string[] args)
        {
            int x, y, ww, wh;
            char c;
            Console.CursorVisible = false;
            ww = Console.WindowWidth;
            wh = Console.WindowHeight;
            x = ww / 2;
            ww--;//Из-за нижнего правого угла
            y = wh / 2;
            Console.SetCursorPosition(x, y);
            Console.Write("@");
            Console.SetCursorPosition(x, y);
            do
            {
                c = (char)Console.ReadKey().Key;
                switch(c){
                    case (char)37:
                        if (x > 0) x--;
                        else x = ww - 1;
                        break;
                    case (char)39: x++; break;
                    case (char)38:
                        if (y > 0) y--;
                        else y = wh - 1;
                        break;
                    case (char)40: y++; break;
                }
                x %= ww;
                y %= wh;
                Console.Write(" ");
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(x, y);
                Console.Write("@");
                Console.SetCursorPosition(x, y);
            } while (c != 27);
        }
    }
}
