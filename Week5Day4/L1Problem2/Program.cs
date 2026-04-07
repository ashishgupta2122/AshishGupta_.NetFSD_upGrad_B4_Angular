using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter folder Path: ");
            string folderPath = Console.ReadLine();

            if (folderPath == null || !Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid Directory Path");
                return;
            }

            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in this folder.");
                return;
            }

            Console.WriteLine("\nFile Details:\n");

            int count = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                Console.WriteLine("File Name     : " + fileInfo.Name);
                Console.WriteLine("File Size     : " + fileInfo.Length + " bytes");
                Console.WriteLine("Creation Date : " + fileInfo.CreationTime);
                Console.WriteLine("----------------------------------");

                count++;
            }

            Console.WriteLine($"\nTotal Files: {count}");
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