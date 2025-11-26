namespace numberguess;

class Program
{
    static void Main(string[] args)
    {
        // Generate random number between 1 and 100
        Random rand = new Random();
        int targetNumber = rand.Next(1, 101);

        // Game variables
        int attempts = 0;
        int maxAttempts = 7;
        bool gameWon = false;

        Console.WriteLine("=== - Number Guessing Game - ===");
        Console.WriteLine("Guess a number between 1 and 100");
        Console.WriteLine($"You have {maxAttempts} attempts");

        // Main game loop
        while (attempts < maxAttempts && !gameWon)
        {
            attempts++;
            Console.Write($"Attempt {attempts}: Enter your guess: ");

            string input = Console.ReadLine();

            // Type casting - convert string to int
            if (int.TryParse(input, out int userGuess))
            {
                // Check guess using if-else statements
                if (userGuess == targetNumber)
                {
                    gameWon = true;
                    Console.WriteLine("-=== Congratulations! You guessed it! ===-");
                }
                else if (userGuess < targetNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    Console.WriteLine("Too high!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
                attempts--; // Don't count invalid input as an attempt
            }
        }

        // End game message using switch statement
        switch (gameWon)
        {
            case true:
                Console.WriteLine($"You won in {attempts} attempts!");
                break;
            case false:
                Console.WriteLine($"Game over! The number was {targetNumber}");
                break;
        }
    }
}
