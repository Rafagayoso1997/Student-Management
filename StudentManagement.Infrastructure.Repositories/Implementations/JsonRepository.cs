using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repositories.Implementations
{
    public class JsonRepository : IRepository
    {

        public IEnumerable<Student> GetAllStudents(string path)
        {
            List<Student> students;
            using (var sr = new StreamReader(path, true))
            {
                students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
            }
            string name = typeof(JsonRepository).AssemblyQualifiedName;
            return students == null ? new List<Student>() : students;

        }

        public Student GetStudentById(int id, string path)
        {
            return GetAllStudents(path).FirstOrDefault(x => x.Id == id);
        }

        public bool SaveStudent(Student student, string path)
        {
            bool inserted = false;
            List<Student> students = (List<Student>)GetAllStudents(path);

            Utils.DeleteIfExist(new FileInfo(path));

            using (var sw = new StreamWriter(path, true))
            {

                students.Add(student);

                if (students.Contains(student))
                    inserted = true;

                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);

            }
            return inserted;

        }

        public bool UpdateStudent(Student student, string path)
        {
            bool updated = false;

            List<Student> students = (List<Student>)GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            using (var sw = new StreamWriter(path, true))
            {

                Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

                int studentindex = students.IndexOf(studentInList);

                students[studentindex] = student;
                if (students.Contains(student))
                    updated = true;

                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);
            }
            return updated;
        }

        public bool DeleteStudent(Student student, string path)
        {
            bool removed = false;
            List<Student> students = (List<Student>)GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            using (var sw = new StreamWriter(path, true))
            {

                Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

                removed = students.Remove(studentInList);

                var json = JsonConvert.SerializeObject(students);
                sw.Write(json);
            }
            return removed;
        }

    }
}
