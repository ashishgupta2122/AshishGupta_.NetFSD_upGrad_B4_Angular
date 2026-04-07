using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Console.WriteLine("\nOrder Processed Successfully!");
            Trace.TraceInformation("Order processed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nOrder Failed");
            Trace.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\nCheck log.txt file for trace details.");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
        Console.WriteLine("Validating Order...");
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");
        Console.WriteLine("Processing Payment...");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
        Console.WriteLine("Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
        Console.WriteLine("Generating Invoice...");
    }
}