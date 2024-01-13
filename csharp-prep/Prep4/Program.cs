using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Core Requirement: Ask the user for a series of numbers and append each one to a list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int input;

        do
        {
            Console.Write("Enter number: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input != 0)
                numbers.Add(input);

        } while (input != 0);

        // Core Requirement 1: Compute the sum of the numbers in the list
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Core Requirement 2: Compute the average of the numbers in the list
        double average = (double)sum / numbers.Count;

        // Core Requirement 3: Find the maximum number in the list
        int maxNumber = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int number in numbers)
        {
            if (number > maxNumber)
                maxNumber = number;
        }

        // Core Requirements: Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenge: Find the smallest positive number
        int smallestPositive = Int32.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
                smallestPositive = number;
        }

        if (smallestPositive == Int32.MaxValue)
            Console.WriteLine("No positive numbers found.");
        else
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch Challenge: Sort the numbers and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
