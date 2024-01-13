using System;

class Program
{
    static void Main()
    {
        // Core Requirement 1: Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        // Core Requirement 2: Add a loop for the game
        bool guessedCorrectly = false;
        int guesses = 0;

        while (!guessedCorrectly)
        {
            // Core Requirement 3: Ask the user for a guess
            Console.Write("What is your guess? ");
            int userGuess = Convert.ToInt32(Console.ReadLine());

            // Check if the guess is correct
            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guessedCorrectly = true;
            }

            // Increment the number of guesses
            guesses++;
        }

        // Stretch Challenge: Display the number of guesses made
        Console.WriteLine($"It took you {guesses} guesses.");

        // Stretch Challenge: Ask if the user wants to play again
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine();

        // Loop back and play again if the user says "yes"
        while (playAgain.ToLower() == "yes")
        {
            // Reset guessedCorrectly and guesses for a new game
            guessedCorrectly = false;
            guesses = 0;

            // Generate a new random magic number for the new game
            Random random = new Random();
            magicNumber = random.Next(1, 101);

            Console.Write("What is the magic number? ");
            // Ask the user for the magic number
            magicNumber = Convert.ToInt32(Console.ReadLine());

            while (!guessedCorrectly)
            {
                Console.Write("What is your guess? ");
                int userGuess = Convert.ToInt32(Console.ReadLine());

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    guessedCorrectly = true;
                }

                guesses++;
            }

            Console.WriteLine($"It took you {guesses} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}
