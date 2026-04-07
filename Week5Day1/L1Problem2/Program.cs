using System;

namespace L1Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Base Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Employee manager = new Manager();
            manager.BaseSalary = salary;

            Employee developer = new Developer();
            developer.BaseSalary = salary;

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
        }
    }
}