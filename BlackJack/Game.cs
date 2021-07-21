using System;
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
        
        private int[] _deck = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
        public Game()
        {
            Player player = new Player();
            Computer computer = new Computer();
            
            StartGame(player, computer);
        }
        public void StartGame(Player player, Computer computer)
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
                    PrintScore(player);
                    Console.WriteLine("Ваш ход:");
                    Console.WriteLine("UpArrow - Скипнуть ход");
                    Console.WriteLine("DownArrow - Взять карту");
                    Console.WriteLine("Escape - Выйти из игры");
                    var key = Console.ReadKey();
                    while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Escape)
                    {
                        key = Console.ReadKey();
                    }

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            player.Score += GetCard();
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
                        computer.Score += GetCard();
                    }
                    else
                    {
                        computer.Status = false;
                    }
                }
            }
            Console.Clear();
            PrintScore(player);
            PrintScore(computer);
            CheckWinner(player, computer);
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

        public int GetCard()
        {
            Random randcard = new Random();
            int x = randcard.Next(0, _deck.Length);
            int card = _deck[x];
            ChangeDeck(x);
            return card;
        }

        public void ChangeDeck(int x)
        {
            int[] buffDeck = new int[_deck.Length-1];
            for (int i = 0; i < x; i++)
            {
                buffDeck[i] = _deck[i];
            }

            for (int i = x+1; i < _deck.Length; i++)
            {
                buffDeck[i-1] = _deck[i];
            }

            _deck = buffDeck;
        }

        public void PrintScore(Unit unit)
        {
            Console.Write("Количество очков игрока ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unit.Name}: {unit.Score}");
            Console.ResetColor();
        }
    }
}