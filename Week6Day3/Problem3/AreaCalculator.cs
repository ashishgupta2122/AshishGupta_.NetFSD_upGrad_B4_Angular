using System;

namespace Problem3
{
    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }
}