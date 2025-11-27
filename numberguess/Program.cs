using System;

namespace numberguess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Number Guessing Game";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================");
            Console.WriteLine("        * NUMBER GUESSING GAME *");
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
            Console.Write("\nDit valg: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                ProgramGuesses game = new ProgramGuesses();
                game.Play();
            }
            else
            {
                UserGuesses game = new UserGuesses();
                game.Play();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==========================================");
            Console.WriteLine("        Tak fordi du spillede!");
            Console.WriteLine("==========================================");
            Console.ResetColor();
        }
    }

    // MODE: PROGRAMMET GÆTTER BRUGERENS TAL

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
                    case "h":
                        min = guess + 1;
                        break;

                    case "l":
                        max = guess - 1;
                        break;

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

    // MODE: BRUGEREN GÆTTER PROGRAMMETS TAL

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
}
