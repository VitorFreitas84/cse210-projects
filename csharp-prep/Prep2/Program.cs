using System;

class Program
{
    static void Main()
    {
        // Core Requirement: Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Core Requirement: Determine the letter grade and check if the user passed
        string letter;

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement: Display the letter grade and a congratulatory/encouraging message
        Console.WriteLine($"Your letter grade is {letter}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard for the next time!");
        }

        // Stretch Challenge: Determine the sign (+/-) for the letter grade
        int lastDigit = (int)(gradePercentage % 10);
        string sign = "";

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // Stretch Challenge: Display both the letter grade and the sign
        Console.WriteLine($"Your final grade is {letter}{sign}.");

        // Pause to see the output before closing the console window
        Console.ReadLine();
    }
}
