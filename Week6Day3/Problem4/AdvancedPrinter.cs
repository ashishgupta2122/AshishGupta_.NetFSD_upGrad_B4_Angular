using System;

namespace Problem4
{
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print(string document)
        {
            Console.WriteLine("Printing: " + document);
        }

        public void Scan(string document)
        {
            Console.WriteLine("Scanning: " + document);
        }

        public void Fax(string document)
        {
            Console.WriteLine("Faxing: " + document);
        }
    }
}