using System;

using System.Collections.Generic;
using System.Threading;

namespace numberguess;

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