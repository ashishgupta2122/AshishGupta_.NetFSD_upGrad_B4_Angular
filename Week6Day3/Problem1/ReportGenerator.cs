using System;
using System.Collections.Generic;

namespace Problem1
{
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n======== Student Report =====");

            foreach (var student in students)
            {
                string result = student.Marks >= 40 ? "Pass" : "Fail";

                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}