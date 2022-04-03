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

        bool SaveStudent(Student student, string path);

        bool UpdateStudent(Student student, string path);

        bool DeleteStudent(Student student, string path);
       
    }
}
