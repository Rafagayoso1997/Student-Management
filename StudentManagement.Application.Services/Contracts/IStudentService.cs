using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services.Contracts
{
    public interface IStudentService
    {
        void SetIRepositoryFactory(Factory factoryType);

        IEnumerable<Student> GetAllStudents(string path);

        Student GetStudentById(int id, string path);

        void SaveStudent(Student student, string path);

        void UpdateStudent(Student student, string path);

        void DeleteStudent(Student student, string path);
       
    }
}
