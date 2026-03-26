using System;

namespace Problem4
{
    public class BasicPrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine("Printing: " + document);
        }
    }
}