using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductCode
    {
        get;
        set;
    }
    public string ProductName
    {
        get;
        set;
    }
    public string Category
    {
        get;
        set;
    }
    public double Mrp
    {
        get;
        set;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Product> products = new List<Product>()
        {
            new Product{ ProductCode=101, ProductName="Soap", Category="FMCG", Mrp=25 },
            new Product{ ProductCode=102, ProductName="Rice", Category="Grain", Mrp=50 },
            new Product{ ProductCode=103, ProductName="Oil", Category="FMCG", Mrp=120 },
            new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
            new Product{ ProductCode=105, ProductName="Shampoo", Category="FMCG", Mrp=30 }
        };

        // 1. FMCG Products
        var result1 = products.Where(p => p.Category == "FMCG");
        Console.WriteLine("FMCG Products:");
        foreach (var p in result1)
        {
            Console.WriteLine(p.ProductName);
        }

        // 2. Grain Products
        var result2 = products.Where(p => p.Category == "Grain");
        Console.WriteLine("\nGrain Products:");
        foreach (var p in result2)
        {
            Console.WriteLine(p.ProductName);
        }

        // 3. Sort by Product Code
        var result3 = products.OrderBy(p => p.ProductCode);
        Console.WriteLine("\nSorted by Product Code:");
        foreach (var p in result3)
        {
            Console.WriteLine(p.ProductCode);
        }

        // 4. Sort by Category
        var result4 = products.OrderBy(p => p.Category);
        Console.WriteLine("\nSorted By Category:");
        foreach (var p in result4)
        {
            Console.WriteLine(p.Category + " - " + p.ProductName);
        }

        // 5. Sort by MRP Ascending
        var result5 = products.OrderBy(p => p.Mrp);
        Console.WriteLine("\nMRP Ascending:");
        foreach (var p in result5)
        {
            Console.WriteLine(p.ProductName + " - " + p.Mrp);
        }

        // 6. Sort by MRP Descending
        var result6 = products.OrderByDescending(p => p.Mrp);
        Console.WriteLine("\nMRP Descending:");
        foreach (var p in result6)
        {
            Console.WriteLine(p.ProductName + " - " + p.Mrp);
        }
        // 7. Group by Category
        var result7 = products.GroupBy(p => p.Category);
        Console.WriteLine("\nGroup by Category:");
        foreach (var group in result7)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group)
            {
                Console.WriteLine("  " + p.ProductName);
            }

        }

        // 8. Group by MRP
        var result8 = products.GroupBy(p => p.Mrp);
        Console.WriteLine("\nGroup by MRP:");
        foreach (var group in result8)
        {
            Console.WriteLine("MRP: " + group.Key);
            foreach (var p in group)
            {
                Console.WriteLine("  " + p.ProductName);
            }

        }

        // 9. Highest price in FMCG
        var result9 = products
            .Where(p => p.Category == "FMCG")
            .OrderByDescending(p => p.Mrp)
            .FirstOrDefault();

        Console.WriteLine("\nHighest Price in FMCG:");
        Console.WriteLine(result9?.ProductName + " - " + result9?.Mrp);

        // 10. Total count
        Console.WriteLine("\nTotal Products: " + products.Count());

        // 11. FMCG count
        Console.WriteLine("FMCG Count: " + products.Count(p => p.Category == "FMCG"));

        // 12. Max price
        Console.WriteLine("Max Price: " + products.Max(p => p.Mrp));

        // 13. Min price
        Console.WriteLine("Min Price: " + products.Min(p => p.Mrp));

        // 14. All below 30?
        Console.WriteLine("All below 30: " + products.All(p => p.Mrp < 30));

        // 15. Any below 30?
        Console.WriteLine("Any below 30: " + products.Any(p => p.Mrp < 30));
    }
}