using System;
using System.Drawing;

namespace Problem3
{
    class Program
    {
        public static void Main(string[] args)
        {
            AreaCalculator calculator = new AreaCalculator();

            Shape rectangle = new Rectangle(10, 5);
            Shape circle = new Circle(7);

            calculator.PrintArea(rectangle);
            calculator.PrintArea(circle);
        }
    }
}