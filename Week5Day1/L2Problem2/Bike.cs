using System;

namespace L2Problem2
{
    public class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            return total - (total * 0.05);   // 5% discount
        }
    }
}