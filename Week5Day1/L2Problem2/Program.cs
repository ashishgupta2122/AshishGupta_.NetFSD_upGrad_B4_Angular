using System;

namespace L2Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Car Rental Rate Per Day: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Rental Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = new Car();   // Polymorphism
            vehicle.Brand = "Toyota";
            vehicle.RentalRatePerDay = rate;

            double total = vehicle.CalculateRental(days);

            Console.WriteLine("Total Rental = " + total);
        }
    }
}