using System;

namespace L2Problem1
{
    public class Product
    {
        private double price;

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }
}