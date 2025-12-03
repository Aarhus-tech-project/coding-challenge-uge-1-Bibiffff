using System;

using System.Collections.Generic;
using System.Threading;

namespace numberguess;

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
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(guess < target ? "For lavt!" : "For højt!");
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
