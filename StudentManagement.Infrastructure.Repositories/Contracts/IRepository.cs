using StudentManagement.Crosscutting.Models;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.Repositories
{
    public interface IRepository
    {
        IEnumerable<Student> GetAllStudents(string path);

        Student GetStudentById(int id, string path);

        bool SaveStudent(Student student, string path);

        bool UpdateStudent(Student student, string path);

        bool DeleteStudent(Student student, string path); 
    }
}
