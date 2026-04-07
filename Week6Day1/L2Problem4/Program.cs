using System;
using System.Threading.Tasks;

class Program
{

    public static async Task<bool> VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying Payment...");
        await Task.Delay(2000);
        Console.WriteLine("Payment Verified");
        return true;
    }

    public static async Task<bool> CheckInventoryAsync()
    {
        Console.WriteLine("Checking Inventory...");
        await Task.Delay(2000);
        Console.WriteLine("Inventory Available");
        return true;
    }

    public static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming Order...");
        await Task.Delay(1500);
        Console.WriteLine("Order Confirmed");
    }

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Order Processing Started...\n");

        bool paymentStatus = await VerifyPaymentAsync();

        if (paymentStatus)
        {
            bool inventoryStatus = await CheckInventoryAsync();

            if (inventoryStatus)
            {
                await ConfirmOrderAsync();
            }
            else
            {
                Console.WriteLine("Order Failed: Inventory not available");
            }
        }
        else
        {
            Console.WriteLine("Order Failed: Payment not verified");
        }

        Console.WriteLine("\nOrder Processing Completed!");
    }
}