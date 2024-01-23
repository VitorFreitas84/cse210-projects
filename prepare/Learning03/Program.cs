using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of Fraction using different constructors
        Fraction f1 = new Fraction();            // Default constructor (1/1)
        Fraction f2 = new Fraction(5);           // Constructor with one parameter (5/1)
        Fraction f3 = new Fraction(3, 4);        // Constructor with two parameters (3/4)
        Fraction f4 = new Fraction(1, 3);        // Constructor with two parameters (1/3)

        // Displaying the fraction and decimal representations for each instance
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}
