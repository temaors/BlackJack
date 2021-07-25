using System;
using BlackJack;

namespace BlackJack
{
    public class Player : Unit
    {
        public Player()
        {
            Score = 0;
        }
        public void PrintScore()
        {
            Console.WriteLine("Ваши карты:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.ResetColor();
            Console.Write("Количество очков: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Score);
            Console.ResetColor();
        }
    }
}