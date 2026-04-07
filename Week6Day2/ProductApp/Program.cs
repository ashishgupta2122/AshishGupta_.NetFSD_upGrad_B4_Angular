using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using ProductApp.Data;
using ProductApp.Models;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        ProductRepository repo = new ProductRepository(config);

        while (true)
        {
            Console.WriteLine("\n==== PRODUCT MANAGEMENT ====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Choose option: ");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    Product p = new Product();

                    Console.Write("Enter Name: ");
                    p.ProductName = Console.ReadLine() ?? "";

                    Console.Write("Enter Category: ");
                    p.Category = Console.ReadLine() ?? "";

                    Console.Write("Enter Price: ");
                    decimal.TryParse(Console.ReadLine(), out decimal price);
                    p.Price = price;

                    repo.InsertProduct(p);
                    break;

                case 2:
                    var list = repo.GetAllProducts();

                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.ProductId} | {item.ProductName} | {item.Category} | {item.Price}");
                    }
                    break;

                case 3:
                    Product up = new Product();

                    Console.Write("Enter ID: ");
                    int.TryParse(Console.ReadLine(), out int id);
                    up.ProductId = id;

                    Console.Write("Enter New Name: ");
                    up.ProductName = Console.ReadLine() ?? "";

                    Console.Write("Enter New Category: ");
                    up.Category = Console.ReadLine() ?? "";

                    Console.Write("Enter New Price: ");
                    decimal.TryParse(Console.ReadLine(), out decimal newPrice);
                    up.Price = newPrice;

                    repo.UpdateProduct(up);
                    break;

                case 4:
                    Console.Write("Enter ID to delete: ");
                    int.TryParse(Console.ReadLine(), out int deleteId);

                    repo.DeleteProduct(deleteId);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}