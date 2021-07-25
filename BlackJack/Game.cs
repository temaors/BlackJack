using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace BlackJack
{
    public class Game
    {
        //Колода - двумерный строковый массив, реализация вариативности очков получаемых от туза(isAce)
        //Уровни сложности компьютера
        //Легкий - >15 очков - скип
        //Средний - проверяет наличие туза на руках
        //Тяжелый - проверяет процент вытягивания карт и сравнивает вероятности набрать больше 21 и меньше
        //Поработать с размерами консоли
        //
        //
        //
        //Связать с базами данных
        //Сделать несколько игр и объединить в хаб развлечений (Hunt the Wumpus)
        //Игра динозаврика из браузера
        //
        //
        //
        //Сделать WPF приложение игры
        
        public string[,] _deck = new string[2,52] { 
            {"two of clubs","two of spades", "two of diamonds","two of hearts",
                "three of clubs","three of spades","three of diamonds","three of hearts",
                "four of clubs","four of spades","four of diamonds","four of hearts",
                "five of clubs","five of spades","five of diamonds","five of hearts",
                "six of clubs","six of spades","six of diamonds","six of hearts",
                "seven of clubs","seven of spades","seven of diamonds","seven of hearts",
                "eight of clubs","eight of spades","eight of diamonds","eight of hearts",
                "nine of clubs","nine of spades","nine of diamonds","nine of hearts",
                "ten of clubs","ten of spades","ten of diamonds","ten of hearts",
                "jack of clubs","jack of spades","jack of diamonds","jack of hearts",
                "queen of clubs","queen of spades","queen of diamonds","queen of hearts",
                "king of clubs","king of spades","king of diamonds","king of hearts",
                "ace of clubs","ace of spades","ace of diamonds","ace of hearts",},
            {"2", "2", "2", "2", "3", "3", "3", "3", "4", "4", "4",
                "4","5", "5","5","5","6", "6", "6", "6", "7", "7",
                "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
                "10",  "10", "10", "10","10", "10", "10","10", "10",
                "10","10", "10", "10","10", "10", "10", "11", "11", "11", "11"} };
        public Game()
        {   
            Player player = new Player();
            Computer computer = new Computer();
            StartGame(computer, player);
        }
        public void StartGame(Computer computer, Player player)
        {
            Console.WriteLine("Добро пожаловать в игру BlackJack v1.0");
            Console.WriteLine("Введите ваше имя:");
            player.Name = Console.ReadLine();
            Console.Clear();
            Instructions();
            while (player.Status || computer.Status)
            {
                Console.Clear();
                if (player.Status)
                {
                    Console.WriteLine("Ваш ход:");
                    Console.WriteLine("UpArrow - Скипнуть ход");
                    Console.WriteLine("DownArrow - Взять карту");
                    Console.WriteLine("Escape - Выйти из игры");
                    player.PrintScore();
                    var key = Console.ReadKey();
                    while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Escape)
                    {
                        key = Console.ReadKey();
                    }

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            ChangeDeck(player.GetCard(_deck));
                            break;
                        case ConsoleKey.UpArrow:
                            player.Status = false;
                            break;
                        case ConsoleKey.Escape:
                            player.Status = false;
                            computer.Status = false;
                            break;
                    }
                }

                Console.Clear();

                if (computer.Status)
                {
                    Console.WriteLine("Ход компьютера...");

                    Thread.Sleep(5000);
                    if (computer.Score < 15)
                    {
                        ChangeDeck(computer.GetCard(_deck));
                    }
                    else
                    {
                        computer.Status = false; 
                    }
                }
            }
            Console.Clear();
            CheckWinner(player, computer);
            PrintFinalScore(computer, player);
        }

        public void PrintFinalScore(Computer computer, Player player)
        {
            Console.WriteLine($"Карты игрока {player.Name}:");
            for (int i = 0; i <= player.AmountOfCards; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(player.Hand[i]);
            }
            Console.ResetColor();
            Console.Write("Количество очков игрока: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(player.Score);
            Console.ResetColor();

            Console.WriteLine($"Карты игрока {computer.Name}:");
            for (int i = 0; i <= computer.AmountOfCards; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(computer.Hand[i]);
            }
            Console.ResetColor();
            Console.Write("Количество очков игрока: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(computer.Score);
            Console.ResetColor();
        }
        public void CheckWinner(Unit player, Unit computer)
        {
            if (computer.Score == player.Score||(player.Score>21 && computer.Score>21))
            {
                Console.WriteLine("Ничья!");
            }
            else
            { 
                if (computer.Score > 21)
                {
                    Console.WriteLine($"Игрок {player.Name} победил!");
                    player.GlobalScore++;
                }
                else
                {
                    if (player.Score > 21)
                    {
                        Console.WriteLine("Игрок Компьютер победил!");
                        computer.GlobalScore++;
                    }
                    else
                    {
                        if (player.Score > computer.Score)
                        {
                            Console.WriteLine($"Игрок {player.Name} победил!");
                            player.GlobalScore++;
                        }
                        else
                        {
                            Console.WriteLine("Игрок Компьютер победил!");
                            computer.GlobalScore++;
                        }
                    }
                }
            }
        }

        public void Instructions()
        {
            Console.WriteLine("Для начала игры выберите уровень сложности");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Лёгкий" );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Средний");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сложный");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UpArrow - Скипнуть ход");
            Console.WriteLine("DownArrow - Взять карту");
            Console.WriteLine("Esc - Выйти из игры");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public void ChangeDeck(int x)
        {
            string[,] buffDeck = new string[2,_deck.GetLength(1)-1];
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    buffDeck[j, i] = _deck[j, i];
                }
            }

            for (int j = 0; j < 2; j++)
            {
                for (int i = x + 1; i < _deck.GetLength(1); i++)
                {
                    buffDeck[j, i - 1] = _deck[j, i];  
                }
            }

            _deck = buffDeck;
        }
    }
}