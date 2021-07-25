using System;

namespace BlackJack
{
    public abstract class Unit
    {
        public Unit()
        {
            Score = 0;
            Status = true;
            string[] Hand = new string[10];
        }
        public int Score { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int AmountOfCards { get; set; }
        public int GlobalScore { get; set; }
        public string[] Hand { get; set; }

        public int GetCard(string[,] _deck)
        {
            Random randcard = new Random();
            int x = randcard.Next(0, _deck.GetLength(1));
            Score += Convert.ToInt32(_deck[1, x]);
            Hand[AmountOfCards] = _deck[0, x];
            AmountOfCards++;
            return x;
        }
    }
}