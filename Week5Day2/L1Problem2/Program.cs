// Program.cs
using System;

namespace SafeDivisionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (true)
            {
                Console.WriteLine("\n===== Safe Division Calculator =====");

                try
                {
                    Console.Write("Enter Numerator: ");
                    int numerator = int.Parse(Console.ReadLine());

                    Console.Write("Enter Denominator: ");
                    int denominator = int.Parse(Console.ReadLine());

                    calculator.Divide(numerator, denominator);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter numeric values only.");
                }

                Console.Write("\nDo you want to continue? (y/n): ");
                string choice = Console.ReadLine().ToLower();

                if (choice != "y")
                    break;
            }

            Console.WriteLine("Program ended.");
        }
    }
}