using System;

class OrderCalculator
{
    public void CalculateFinalAmount(double price, int quantity, double discountPercent = 0, double shippingCharge = 50)
    {
        double subtotal = price * quantity;

        double discountAmount = subtotal * (discountPercent / 100);

        double amountAfterDiscount = subtotal - discountAmount;

        double finalAmount = amountAfterDiscount + shippingCharge;

        Console.WriteLine("Subtotal: " + subtotal);
        Console.WriteLine("Discount Applied: " + discountAmount);
        Console.WriteLine("Shipping Charge: " + shippingCharge);
        Console.WriteLine("Final Amount: " + finalAmount);
    }
}

class Program
{
    public static void Main(string[] args)
    {

        OrderCalculator order = new OrderCalculator();

        Console.Write("Enter Product Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n--- Without Discount (Default Values) ---");
        order.CalculateFinalAmount(price, quantity);

        Console.WriteLine("\n--- With Discount Only ---");
        order.CalculateFinalAmount(price, quantity, 10);

        Console.WriteLine("\n--- With Discount and Custom Shipping ---");
        order.CalculateFinalAmount(price, quantity, 10, 100);
    }
}