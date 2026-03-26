using System;

namespace Problem4
{
    class Program
    {
        public static void Main(string[] args)
        {
            IPrinter basicPrinter = new BasicPrinter();
            basicPrinter.Print("Basic Document");

            Console.WriteLine();

            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            advancedPrinter.Print("Advanced Document");
            advancedPrinter.Scan("Advanced Document");
            advancedPrinter.Fax("Advanced Document");
        }
    }
}