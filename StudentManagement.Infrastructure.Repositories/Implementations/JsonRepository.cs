using Newtonsoft.Json;
using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repositories.Contracts
{
    public class JsonRepository : IRepository
    {
        private IEnumerable<Student> _students;
        public IEnumerable<Student> GetAllStudents(string path)
        {
            _students = new List<Student>();
            using (var sr = new StreamReader(path, true))
            {
                _students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
            }
            return _students;

        }

        public Student GetStudentById(int id)
        {
            return _students.Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

    }
}
