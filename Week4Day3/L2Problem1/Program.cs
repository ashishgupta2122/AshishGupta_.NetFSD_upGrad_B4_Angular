using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        int experience = Convert.ToInt32(Console.ReadLine());

        double bonusPercent;

        if (experience < 2)
        {
            bonusPercent = 0.05;
        }
        else if (experience <= 5)
        {
            bonusPercent = 0.10;
        }
        else
        {
            bonusPercent = 0.15;
        }

        double bonus = salary * bonusPercent;

        double finalSalary = bonus > 0 ? salary + bonus : salary;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus.ToString("C"));
        Console.WriteLine("Final Salary: " + finalSalary.ToString("C"));
    }
}