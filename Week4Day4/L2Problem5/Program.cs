using System;

class PowerCalculator
{
    public int CalculatePower(int baseNumber, int exponent)
    {
        if (exponent == 0)
        {
            return 1;
        }

        return baseNumber * CalculatePower(baseNumber, exponent - 1);
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Base: ");
        int baseNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        if (exponent < 0)
        {
            Console.WriteLine("Exponent must be a Positive integer.");
            return;
        }

        PowerCalculator calculator = new PowerCalculator();

        int result = calculator.CalculatePower(baseNumber, exponent);

        Console.WriteLine("Base: " + baseNumber);
        Console.WriteLine("Exponent: " + exponent);
        Console.WriteLine("Result: " + result);

    }
}