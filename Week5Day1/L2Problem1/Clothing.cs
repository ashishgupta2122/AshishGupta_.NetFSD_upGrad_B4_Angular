using System;

namespace L2Problem1
{
    public class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }
}