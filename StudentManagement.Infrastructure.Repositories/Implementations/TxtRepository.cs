using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repositories.Implementations
{
    public class TxtRepository : IRepository
    {
        public IEnumerable<Student> GetAllStudents(string path)
        {
             List<Student> students = File.ReadAllLines(path)
                    .Select(line => Utils.mapStudentFromTextToList(line))
                    .ToList();

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

            students.Add(student);
            if(students.Contains(student))
                inserted = true;    

            File.WriteAllLines(path,
                students.Select(st => st.ToString()), Encoding.UTF8);

            return inserted;
        }

        public bool UpdateStudent(Student student, string path)
        {
            bool updated = false;

            List<Student> students = (List<Student>)GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            int studentindex = students.IndexOf(studentInList);

            students[studentindex] = student;

            if(students.Contains(student))
                updated = true;

            File.WriteAllLines(path,
                 students.Select(st => st.ToString()), Encoding.UTF8);

            return updated;
        }

        public bool DeleteStudent(Student student, string path)
        {
            
            List<Student> students = (List<Student>)GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));



            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            bool removed = students.Remove(studentInList);

           

            File.WriteAllLines(path,
                 students.Select(st => st.ToString()), Encoding.UTF8);

            return removed;

        }

    }
}
