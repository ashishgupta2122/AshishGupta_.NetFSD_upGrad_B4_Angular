using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("==== Drive Information =====\n");

            foreach (DriveInfo drive in drives)
            {
                if (!drive.IsReady)
                {
                    Console.WriteLine($"Drive Name : {drive.Name}");
                    Console.WriteLine("Status   : Not Ready");
                    Console.WriteLine("--------------------");
                    continue;
                }

                //calculate values
                long totalSize = drive.TotalSize;
                long freeSpace = drive.TotalFreeSpace;

                double freePercentage = (freeSpace * 100.0) / totalSize;

                Console.WriteLine($"Drive Name   : {drive.Name}");
                Console.WriteLine($"Drive Type   : {drive.DriveType}");
                Console.WriteLine($"Total Size   : {totalSize / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"Free Space   : {freeSpace / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"Free %       : {freePercentage:F2}%");

                // Warning condition
                if (freePercentage < 15)
                {
                    Console.WriteLine("Warning: Low Disk Space!");
                }

                Console.WriteLine("----------------------------------");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied! Unable to read drive info.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}