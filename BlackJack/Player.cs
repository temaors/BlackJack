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
            Console.WriteLine("���� �����:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.ResetColor();
            Console.Write("���������� �����: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Score);
            Console.ResetColor();
        }
    }
}