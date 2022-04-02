using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        
        public List<Student> GetAllStudents(string path)
        {
            List<Student> students = new List<Student>();
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
            List<Student> students = GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            using (var sw = new StreamWriter(path, true))
            {
                
                students.Append(student);

               

                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);
            }

        }

        public void UpdateStudent(Student student, string path)
        {
            List<Student> students = GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            using (var sw = new StreamWriter(path, true))
            {

                Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);
                
                int studentindex = students.IndexOf(studentInList);

                students[studentindex] = student;

                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);
            }
        }

        public void DeleteStudent(Student student, string path)
        {
            throw new NotImplementedException();
        }

    }
}
