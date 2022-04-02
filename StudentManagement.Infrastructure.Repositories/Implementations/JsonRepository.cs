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
        
        public IEnumerable<Student> GetAllStudents(string path)
        {
            IEnumerable<Student> students = new List<Student>();
            using (var sr = new StreamReader(path, true))
            {
                students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
            }
            return students;

        }

        public Student GetStudentById(int id, string path)
        {
            return GetAllStudents(path).Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveStudent(Student student, string path)
        {
            using (var sw = new StreamWriter(path, true))
            {
                IEnumerable<Student> students  = GetAllStudents(path);
                students.Append(student);
                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);
            }

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
