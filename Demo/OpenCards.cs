using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class OpenCards
    {
        List<Card> _cards = new List<Card>(52);
        public List<Card> Cards
        {
            get
            {
                return _cards;
            }
        }
        public void RemoveAll()
        {
            _cards.RemoveRange(0, _cards.Count);
        }
        public void Add(Card card)
        {
            _cards.Add(new Card(card));
        }

        public bool Check(Card card)
        {
            if (_cards.Count == 0) return false;
            return _cards[_cards.Count - 1] == card;
        }
        public int Count
        {
            get
            {
                return _cards.Count;
            }
        }

    }
}

