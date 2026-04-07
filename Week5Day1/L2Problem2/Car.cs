using System;

namespace L2Problem2
{
    public class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            return total + 500;   // Insurance charge
        }
    }
}