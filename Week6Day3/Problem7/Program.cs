using System;
using Problem7.Models;
using Problem7.Repository;

namespace Problem7
{
    class Program
    {
        public static void Main(string[] args)
        {
            IStudentRepository repo = new StudentRepository();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Ashish", Course = "MERN" });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Basu", Course = "Java" });

            Console.WriteLine("All Students");
            foreach (var student in repo.GetAllStudents())
            {
                Console.WriteLine($"ID: {student.StudentId}, Name: {student.StudentName}, Course: {student.Course}");
            }

            Console.WriteLine("\nSearch Student with ID = 1:");
            var foundStudent = repo.GetStudentById(1);
            if (foundStudent != null)
            {
                Console.WriteLine($"Found: {foundStudent.StudentName}, Course: {foundStudent.Course}");
            }

            Console.WriteLine("\nDeleting Student with ID = 2");
            repo.DeleteStudent(2);

            Console.WriteLine("\nStudents After Deletion:");
            foreach (var student in repo.GetAllStudents())
            {
                Console.WriteLine($"ID: {student.StudentId}, Name: {student.StudentName}, Course: {student.Course}");
            }
        }
    }
}