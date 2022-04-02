using StudentManagement.Crosscutting.Models;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.Repositories
{
    public interface IRepository
    {
        IEnumerable<Student> GetAllStudents(string path);

        Student GetStudentById(int id, string path);

        void SaveStudent(Student student, string path);

        void UpdateStudent(Student student, string path);

        void DeleteStudent(Student student, string path); 
    }
}
