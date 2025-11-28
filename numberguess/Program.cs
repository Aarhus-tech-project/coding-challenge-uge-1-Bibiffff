using System;
using System.Collections.Generic;
using System.Threading;

namespace numberguess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Number Guessing Game + Snake";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================");
            Console.WriteLine("     * SNAKE + NUMBER GUESSING GAME *");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Game game = new Game();
            game.Start();
        }
    }

    // GAME MENU

    class Game
    {
        public void Start()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vælg spilmode:");
            Console.ResetColor();

            Console.WriteLine(" 1) Programmet gætter dit tal");
            Console.WriteLine(" 2) Du gætter programmets tal");
            Console.WriteLine(" 3) Snake");
            Console.Write("\nDit valg: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                ProgramGuesses game = new ProgramGuesses();
                game.Play();
            }
            else if (choice == "2")
            {
                UserGuesses game = new UserGuesses();
                game.Play();
            }
            else if (choice == "3")
            {
                SnakeGame game = new SnakeGame();
                game.Play();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ugyldigt valg.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==========================================");
            Console.WriteLine("        Tak fordi du spillede!");
            Console.WriteLine("==========================================");
            Console.ResetColor();
        }
    }

    // MODE 1: PROGRAMMET GÆTTER BRUGERENS TAL

    class ProgramGuesses
    {
        public void Play()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Programmet skal gætte dit tal!");
            Console.ResetColor();

            Console.Write("  Indtast minimum-værdi: ");
            int min = GetValidNumber();

            Console.Write("  Indtast maksimum-værdi: ");
            int max = GetValidNumber();

            Console.Write("\nTænk på et tal i området og tryk ENTER...");
            Console.ReadLine();

            bool guessed = false;

            while (!guessed && min <= max)
            {
                int guess = (min + max) / 2;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nJeg gætter: {guess}");
                Console.ResetColor();

                Console.Write("Svar (h = højere, l = lavere, j = ja): ");
                string response = Console.ReadLine().ToLower();

                switch (response)
                {
                    case "h": min = guess + 1; break;
                    case "l": max = guess - 1; break;

                    case "j":
                        guessed = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nJeg gættede det!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Skriv h, l eller j.");
                        Console.ResetColor();
                        break;
                }
            }

            if (!guessed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der skete en fejl");
                Console.ResetColor();
            }
        }

        private int GetValidNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int n))
                    return n;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ugyldigt tal, prøv igen: ");
                Console.ResetColor();
            }
        }
    }

    // MODE 2: BRUGEREN GÆTTER PROGRAMMETS TAL

    class UserGuesses
    {
        public void Play()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDu skal gætte programmets tal!");
            Console.ResetColor();

            Console.Write("Indtast minimum-værdi: ");
            int min = GetValidNumber();

            Console.Write("Indtast maksimum-værdi: ");
            int max = GetValidNumber();

            Random rand = new Random();
            int target = rand.Next(min, max + 1);

            bool won = false;

            while (!won)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nDit gæt: ");
                Console.ResetColor();

                int guess = GetValidNumber();

                if (guess == target)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Rigtigt! Du gættede tallet!");
                    Console.ResetColor();
                    won = true;
                }
                else if (guess < target)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(" For lavt!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(" For højt!");
                    Console.ResetColor();
                }
            }
        }

        private int GetValidNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int n))
                    return n;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ikke et tal! Prøv igen: ");
                Console.ResetColor();
            }
        }
    }

    // MODE 3: SNAKE GAME MED SCOREBOARD

    class SnakeGame
    {
        enum Direction { Up, Down, Left, Right }

        public void Play()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int width = 40;
            int height = 20;
            int score = 0;

            DrawBorder(width, height);
            ShowScore(score);

            var snake = new LinkedList<(int x, int y)>();
            snake.AddFirst((width / 2, height / 2));
            snake.AddLast((width / 2 - 1, height / 2));
            snake.AddLast((width / 2 - 2, height / 2));

            Direction dir = Direction.Right;

            Random rand = new Random();
            (int x, int y) food = PlaceFood(rand, width, height, snake);
            Draw(food.x, food.y, '*');

            bool alive = true;
            int delay = 120;

            while (alive)
            {
                // Input
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    dir = ChangeDirection(dir, key);
                }

                // New head
                var head = snake.First.Value;
                var newHead = head;

                switch (dir)
                {
                    case Direction.Up: newHead.y--; break;
                    case Direction.Down: newHead.y++; break;
                    case Direction.Left: newHead.x--; break;
                    case Direction.Right: newHead.x++; break;
                }

                // Collisions
                if (newHead.x <= 0 || newHead.x >= width - 1 ||
                    newHead.y <= 1 || newHead.y >= height - 1)
                    alive = false;

                foreach (var s in snake)
                    if (s.x == newHead.x && s.y == newHead.y)
                        alive = false;

                if (!alive) break;

                // Move snake
                snake.AddFirst(newHead);
                Draw(newHead.x, newHead.y, 'O');

                // FOOD
                if (newHead == food)
                {
                    score++;
                    ShowScore(score);

                    food = PlaceFood(rand, width, height, snake);
                    Draw(food.x, food.y, '*');
                }
                else
                {
                    var tail = snake.Last.Value;
                    snake.RemoveLast();
                    Draw(tail.x, tail.y, ' ');
                }

                Thread.Sleep(delay);
            }

            // GAME OVER
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, height + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGame Over!");
            Console.ResetColor();
            Console.WriteLine($"Din score: {score}");
        }

        // ----- Helpers -----

        Direction ChangeDirection(Direction current, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow && current != Direction.Down) return Direction.Up;
            if (key == ConsoleKey.DownArrow && current != Direction.Up) return Direction.Down;
            if (key == ConsoleKey.LeftArrow && current != Direction.Right) return Direction.Left;
            if (key == ConsoleKey.RightArrow && current != Direction.Left) return Direction.Right;

            return current;
        }

        void Draw(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        void ShowScore(int score)
        {
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"            Score: {score}   ");
            Console.ResetColor();
        }

        void DrawBorder(int width, int height)
        {
            Console.Clear();

            // Top border with scoreboard space
            for (int x = 0; x < width; x++)
                Draw(x, 1, '#');

            // Bottom
            for (int x = 0; x < width; x++)
                Draw(x, height - 1, '#');

            // Sides
            for (int y = 1; y < height; y++)
            {
                Draw(0, y, '#');
                Draw(width - 1, y, '#');
            }
        }

        (int x, int y) PlaceFood(Random r, int width, int height, LinkedList<(int x, int y)> snake)
        {
            int x, y;
            bool taken;

            do
            {
                x = r.Next(1, width - 1);
                y = r.Next(2, height - 1);

                taken = false;

                foreach (var s in snake)
                    if (s.x == x && s.y == y)
                        taken = true;

            } while (taken);

            return (x, y);
        }
    }
}
