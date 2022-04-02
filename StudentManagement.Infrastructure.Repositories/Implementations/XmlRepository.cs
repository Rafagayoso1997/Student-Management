using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repositories.Contracts
{
    public class XmlRepository : IRepository
    {
        public IEnumerable<Student> GetAllStudents(string path)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id, string path)
        {
            throw new NotImplementedException();
        }

        public void SaveStudent(Student student, string path)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student, string path)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student, string path)
        {
            throw new NotImplementedException();
        }

    }
}
