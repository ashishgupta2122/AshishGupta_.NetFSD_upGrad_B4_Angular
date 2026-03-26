using System.Collections.Generic;
using Problem7.Models;

namespace Problem7.Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }
}