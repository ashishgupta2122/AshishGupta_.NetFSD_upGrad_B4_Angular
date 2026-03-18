// StudentService.cs
using System;
using System.Collections.Generic;

namespace StudentRecordSystem
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();

        // Add Student
        public void AddStudent()
        {
            int rollNumber, marks;

            while (true)
            {
                Console.Write("Enter Roll Number: ");
                if (int.TryParse(Console.ReadLine(), out rollNumber) && rollNumber > 0)
                    break;
                Console.WriteLine("Invalid Roll Number!");
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter Marks (0-100): ");
                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                    break;
                Console.WriteLine("Invalid Marks!");
            }

            students.Add(new Student(rollNumber, name, course, marks));
            Console.WriteLine("Student added successfully!");
        }

        // Display Students
        public void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            Console.WriteLine("\n===== Student Records =====");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // Search Student
        public void SearchStudent()
        {
            Console.Write("Enter Roll Number to search: ");
            if (!int.TryParse(Console.ReadLine(), out int roll))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            var student = students.Find(s => s.RollNumber == roll);

            Console.WriteLine("\n===== Search Result =====");
            if (student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
    }
}