using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Place
    {
        private int x, y;
        public Place()
        {
            x = 0;
            y = 0;
        }
        public Place(int X, int Y)
        {
            x = X;
            y = Y;
        }
        //---------------------
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        //---------------------
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
