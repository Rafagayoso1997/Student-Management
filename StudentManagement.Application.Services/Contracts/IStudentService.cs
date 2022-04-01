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

        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int id);

        void SaveStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);
       
    }
}
