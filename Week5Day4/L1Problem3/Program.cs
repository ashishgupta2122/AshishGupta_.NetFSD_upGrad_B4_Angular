using System;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Sales Amount: ");
            decimal sales = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Customer Rating (1-5): ");
            int rating = Convert.ToInt32(Console.ReadLine());

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }

            var result = GetEmployeeData(sales, rating);

            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            Console.WriteLine("\n===== Employee Performance =====");
            Console.WriteLine($"Employee Name : {name}");
            Console.WriteLine($"Sales Amount  : {result.sales}");
            Console.WriteLine($"Rating        : {result.rating}");
            Console.WriteLine($"Performance   : {performance}");

        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Input! Please enter numeric values.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static (decimal sales, int rating) GetEmployeeData(decimal sales, int rating)
    {
        return (sales, rating);
    }
}