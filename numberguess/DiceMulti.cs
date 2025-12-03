using System;

namespace numberguess
{
    class DiceMulti
    {
        public void DicePlay()
        {
            Console.Clear();

            int playerOne;
            int playerTwo;

            int playerOnePoints = 0;
            int playerTwoPoints = 0;

            Random DiceRandom = new Random();

            for (int i = 0; i < 3; i++)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("======================================");
                Console.WriteLine($"           * ROUND {i + 1} *");
                Console.WriteLine("======================================");
                Console.ResetColor();
                // Player 1
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("           Player 1's turn");
                Console.ResetColor();
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey();

                playerOne = DiceRandom.Next(1, 7);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n           Player 1 rolled: {playerOne}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------------------");
                Console.ResetColor();

                // Player 2
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("           Player 2's turn");
                Console.ResetColor();
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey();

                playerTwo = DiceRandom.Next(1, 7);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n           Player 2 rolled: {playerTwo}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------------------");
                Console.ResetColor();

                // Round result
                if (playerOne > playerTwo)
                {
                    playerOnePoints++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPlayer 1 WINS this round!");
                }
                else if (playerOne < playerTwo)
                {
                    playerTwoPoints++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPlayer 2 WINS this round!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\nThis round is a DRAW!");
                }
                Console.ResetColor();

                // Current score
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nCurrent Score:\nPlayer 1: {playerOnePoints}\nPlayer 2: {playerTwoPoints}");
                Console.WriteLine("-------------------------------------\n");
                Console.ResetColor();
            }

            // Final result
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("====== FINAL RESULT ======");
            Console.ResetColor();

            if (playerOnePoints > playerTwoPoints)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPlayer 1 WINS the game!");
            }
            else if (playerOnePoints < playerTwoPoints)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlayer 2 WINS the game!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nThe game is a DRAW!");
            }
            Console.ResetColor();
        }
    }
}
