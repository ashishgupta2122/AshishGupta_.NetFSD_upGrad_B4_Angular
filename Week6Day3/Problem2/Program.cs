using System;

namespace Problem2
{
    class Program
    {
        public static void Main(string[] args)
        {
            double amount = 1000;

            var regular = new DiscountCalculator(new RegularCustomerDiscount());
            Console.WriteLine("Regular Customer Final Price: " + regular.GetFinalPrice(amount));

            var premium = new DiscountCalculator(new PremiumCustomerDiscount());
            Console.WriteLine("Premium Customer Final Price: " + premium.GetFinalPrice(amount));

            var vip = new DiscountCalculator(new VipCustomerDiscount());
            Console.WriteLine("VIP Customer Final Price: " + vip.GetFinalPrice(amount));
        }
    }
}