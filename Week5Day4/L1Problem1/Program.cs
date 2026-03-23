using System;
using System.IO;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        string filePath = "log.txt";

        try
        {
            Console.WriteLine("Enter Your Message (type 'exit' to stop):");

            while (true)
            {
                Console.Write("Message: ");
                string message = Console.ReadLine();

                // Null check
                if (message == null)
                    continue;

                if (message.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting Application..");
                    break;
                }

                byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                using (FileStream fs = new FileStream(
                    filePath,
                    FileMode.Append,
                    FileAccess.Write
                ))
                {
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message written successfully!\n");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You don't have permission to access the file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}