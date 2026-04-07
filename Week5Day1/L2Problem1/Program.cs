using System;

namespace L2Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Electronics Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product product = new Electronics();
            product.Name = "Laptop";
            product.Price = price;

            double finalPrice = product.CalculateDiscount();

            Console.WriteLine("Final Price after 5% discount = " + finalPrice);
        }
    }
}