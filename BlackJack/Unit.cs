using System;
using System.Collections.Generic;

namespace BlackJack
{
    public abstract class Unit
    {
        public Unit()
        {
            Score = 0;
            AmountOfCards = 0;
            Status = true;
        }
        public int Score { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int AmountOfCards { get; set; }
        public int GlobalScore { get; set; }
        public string[] Hand { get; set; }
        //public List<string> Hands { get; set; }

        public int GetCard(string[,] _deck)
        {
            Random randcard = new Random();
            int x = randcard.Next(0, _deck.GetLength(1));
            Score += Convert.ToInt32(_deck[1, x]);
            Hand[AmountOfCards] = _deck[0, x];
            AmountOfCards++;
            isAce();
            return x;
        }

        public void isAce()
        {
            if (Score > 21)
            {
                foreach (string card in Hand)
                {
                    if (card == null)
                    {
                        break;
                    }
                    int res = card.IndexOf("ace");
                    if (res>-1)
                    {
                        Score -= 10;
                    }
                }
            }
        }
    }
}