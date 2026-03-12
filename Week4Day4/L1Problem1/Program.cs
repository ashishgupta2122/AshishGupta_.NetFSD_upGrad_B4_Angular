using System;

class Calculator
{
    public int add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter First Number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Calculator cal = new Calculator();
        int addition = cal.add(num1, num2);
        int subtraction = cal.Subtract(num1, num2);

        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);

    }
}