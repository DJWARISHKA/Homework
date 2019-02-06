using System;

namespace Demo
{
    class Game
    {
        Player[] _players = new Player[4];
        CardDeck _cardDeck = new CardDeck();
        OpenCards _openCards = new OpenCards();
        bool winner;
        public void BeginGame()
        { 
        Console.OutputEncoding = System.Text.Encoding.UTF8;
            string command;
            Card playCard = new Card();
            int playerCount;
            do
            {
                Console.WriteLine("Добро пожаловать в игру 'Свинья'");
                Console.Write("Введите кол-во игроков: ");
                playerCount = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (playerCount < 0 && playerCount > 4);
            Console.SetCursorPosition(0, 6);
            Console.Write("Press anykey to start");
            Console.ReadKey(true);
            Console.Clear();
            _openCards = new OpenCards();
            for (int i = 0; i < playerCount; i++)
            {
                _players[i] = new Player();
            }
            do
            {
                for (int i = 0; i < playerCount; i++) 
                {
                    ShowHead();
                    Console.Write($"Ход игрока {i + 1}           ");
                    Console.ReadKey(true);
                    Console.SetCursorPosition(0, 7);
                    if (_players[i].empty)
                    {
                        
                        Console.Write("Взять карту              ");
                        Console.ReadKey(true);
                        playCard = new Card(_cardDeck.NextCard);
                        
                    }
                    else
                    {
                        Console.Write("Положить карту           ");
                        Console.ReadKey(true);                        
                        _players[i].ShowCards();
                        playCard = new Card(_players[i].GiveCard());
                        Console.SetCursorPosition(10, 1);
                        playCard.Show();
                    }
                    ShowHead();
                    Console.SetCursorPosition(10, 1);
                    playCard.Show();
                    Console.ReadKey(true);
                    if (_openCards.Check(playCard))
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.Write("Тебе не повезло           ");
                        _players[i].Hand = _openCards.Cards;
                        _openCards.RemoveAll();
                        Console.ReadKey(true);
                    }
                    if (_cardDeck.Count == 0 && _players[i].empty)
                        winner = true;
                    _openCards.Add(playCard);
                }
            } while (!winner);
            Console.Clear();
            for (int i = 0; i < playerCount; i++)
            {
                if (_players[i].empty)
                    Console.WriteLine($"Игрок №{i + 1}- карт {_players[i].Hand.Count} - Победил");
                else
                    Console.WriteLine($"Игрок №{i + 1}- карт {_players[i].Hand.Count} - Проиграл");
            }
            
        }
        void ShowHead()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write($"Карт в колоде {_cardDeck.Count}; Карт открыто {_openCards.Count}          ");
            Console.SetCursorPosition(0, 1);
            if (_openCards.Cards.Count > 0)
                _openCards.Cards[_openCards.Cards.Count - 1].Show();
            Console.SetCursorPosition(0, 6);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.BeginGame();
        }
    }
}
