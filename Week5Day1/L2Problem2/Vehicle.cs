using System;

namespace L2Problem2
{
    public class Vehicle
    {
        private double rentalRatePerDay;

        public string Brand { get; set; }

        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rental rate cannot be negative");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }

        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }
}