using System;

namespace L2Problem1
{
    public class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }
}