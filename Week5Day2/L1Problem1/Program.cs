// Program.cs
using System;

namespace StudentRecordSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService();
            int choice;

            do
            {
                Console.WriteLine("\n===== Student Record Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        service.AddStudent();
                        break;

                    case 2:
                        service.DisplayStudents();
                        break;

                    case 3:
                        service.SearchStudent();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4);
        }
    }
}