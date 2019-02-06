using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Player
    {
        List<Card> _hand = new List<Card>(52);
        public bool empty = true;
        public List<Card> Hand
        {
            get
            {
                return _hand;
            }
            set
            {
                foreach (Card item in value)
                {
                    _hand.Add(new Card(item));
                }
                empty = false;
            }
        }
        public Card GiveCard()
        {
            int ind = 0;
            string tmp1;
            do
            {
                Console.SetCursorPosition(0, 7);
                Console.Write("Положить карту: №");
                do
                {
                    tmp1 = Console.ReadLine();
                } while (!int.TryParse(tmp1, out ind));
                ind = int.Parse(tmp1) - 1;
            } while (ind < 0 || ind >= _hand.Count);
            Card tmp = new Card(_hand[ind]);
            _hand.RemoveAt(ind);
            if (_hand.Count == 0)
                empty = true;
            return new Card(tmp);
        }
        public void ShowCards()
        {
            Console.SetCursorPosition(0, 9);
            for (int i = 0; i < _hand.Count; i++)
            {
                if ((Console.CursorLeft + 13) > Console.WindowWidth) 
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 5);
                }
                Console.Write($" {i + 1}) ");
                _hand[i].Show();
            }
        }
    }
}
