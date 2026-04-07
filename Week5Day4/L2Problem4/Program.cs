using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Root Directory Path: ");
            string path = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            // Create DirectoryInfo object
            DirectoryInfo root = new DirectoryInfo(path);

            // Get subdirectories
            DirectoryInfo[] directories = root.GetDirectories();

            if (directories.Length == 0)
            {
                Console.WriteLine("No subdirectories found.");
                return;
            }

            Console.WriteLine("\n📁 Folder Analysis:\n");

            foreach (DirectoryInfo dir in directories)
            {
                try
                {
                    // Count files in each directory
                    FileInfo[] files = dir.GetFiles();
                    int fileCount = files.Length;

                    Console.WriteLine($"Folder Name : {dir.Name}");
                    Console.WriteLine($"File Count  : {fileCount}");
                    Console.WriteLine("----------------------------------");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Folder Name : {dir.Name}");
                    Console.WriteLine("Access Denied!");
                    Console.WriteLine("----------------------------------");
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied! You don't have permission.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}