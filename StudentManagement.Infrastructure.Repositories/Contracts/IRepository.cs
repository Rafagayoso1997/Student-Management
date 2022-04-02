using StudentManagement.Crosscutting.Models;
using System.Collections.Generic;

namespace StudentManagement.Infrastructure.Repositories
{
    public interface IRepository
    {
        IEnumerable<Student> GetAllStudents(string path);

        Student GetStudentById(int id);

        void SaveStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student); 
    }
}
