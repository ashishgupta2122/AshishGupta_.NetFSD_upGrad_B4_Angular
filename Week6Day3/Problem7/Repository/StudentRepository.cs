using System.Collections.Generic;
using System.Linq;
using Problem7.Models;

namespace Problem7.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}