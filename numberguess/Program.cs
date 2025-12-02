using System;

using System.Collections.Generic;
using System.Threading;

namespace numberguess;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Number Guessing Game + Maze";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==========================================");
        Console.WriteLine("     * MAZE + NUMBER GUESSING GAME *");
        Console.WriteLine("==========================================");
        Console.ResetColor();

        Game game = new Game();
        game.Start();
    }
}