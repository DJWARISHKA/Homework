using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Card
    {
        int _mast;
        int _weight;
        static readonly string[] masts = { "♠", "♣", "♥", "♦" };
        static readonly string[] names = {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Валет",
            "Дама",
            "Король",
            "Туз"
        };
        public Card()
        {
            _mast = -1;
        }
        public Card(int card)
        {
            _mast = card / 13;
            _weight = card % 13;
        }
        public Card(Card card)
        {
            _mast = card._mast;
            _weight = card._weight;
        }
        public override string ToString()
        {
            return $"{masts[_mast]}{names[_weight]}";
        }
        public void Show()
        {
            if (_mast == -1) return;
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.Write("╔══════╗");
            Console.SetCursorPosition(x, ++y);
            Console.Write($"║{names[_weight]}".PadRight(7)+ "║");
            Console.SetCursorPosition(x, ++y);
            Console.Write($"║{masts[_mast]}".PadRight(7)+ "║");
            Console.SetCursorPosition(x, ++y);
            Console.Write("╚══════╝");
            Console.SetCursorPosition((x + 8) % Console.WindowWidth, y - 3);
        }
        public static bool operator ==(Card card1, Card card2)
        {
            //if (card1 == null)
            //{
            //    throw new ArgumentNullException(nameof(card2));
            //}

            if (card1._mast == card2._mast)
                return true;
            return false;
        }
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }
    class CardDeck
    {
        int[] _deck = { 0, 1, 2, 3, 4, 5, 6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
        31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51 };
        int _current = 0;
        private void RandomShiffle()
        {
            for (int i = 0; i < _deck.Length; i++)
            {
                int rnd = _rnd.Next(_deck.Length);
                int tmp = _deck[i];
                _deck[i] = _deck[rnd];
                _deck[rnd] = tmp;
            }
        }
        Random _rnd;
        public CardDeck(int n = -1)
        {
            if (n < 0)
                _rnd = new Random();
            else
                _rnd = new Random(n);
            RandomShiffle();
        }
        public Card NextCard
        {
            get
            {
                //_current %= 52;
                return new Card(_deck[_current++]);
            }
        }
        public int Count
        {
            get
            {
                return 52 - _current;
            }
        }
    }

}
