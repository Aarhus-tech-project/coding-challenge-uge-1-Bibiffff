using System;

using System.Collections.Generic;
using System.Threading;

namespace numberguess;

// GAME MENU
class Game
{
    public void Start()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Vælg spilmode:");
        Console.ResetColor();

        // Spil muligheder
        Console.WriteLine(" 1) Programmet gætter dit tal");
        Console.WriteLine(" 2) Du gætter programmets tal");
        Console.WriteLine(" 3) Dice");
        Console.Write("\nDit valg: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new ProgramGuesses().Play();
                break;

            case "2":
                new UserGuesses().Play();
                break;

            case "3":
                new Dice().DicePlay();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ugyldigt valg.");
                Console.ResetColor();
                break;
        }

        // Besked når spillet er færdigt
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==========================================");
        Console.WriteLine("        Tak fordi du spillede!");
        Console.WriteLine("==========================================");
        Console.ResetColor();
    }
}

