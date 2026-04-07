using System;

namespace Problem1
{
    class Program
    {
        public static void Main(string[] args)
        {
            StudentRepository repo = new StudentRepository();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Ashish", Marks = 85 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Basu", Marks = 82 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Akash", Marks = 79 });

            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(repo.GetAllStudents());

            Console.ReadLine();
        }
    }
}