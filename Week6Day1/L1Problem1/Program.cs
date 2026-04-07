using System;
using System.Threading.Tasks;

class Program
{
    public static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start Writing: {message}");

        await Task.Delay(2000);

        Console.WriteLine($"Finished Writing: {message}");
    }
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Loggging Started..\n");

        Task task1 = WriteLogAsync("Log 1: User logged in");
        Task task2 = WriteLogAsync("Log 2: Data processed");
        Task task3 = WriteLogAsync("Log 3: File uploaded");

        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("\nAll Logs Written Successfully!");
    }
}