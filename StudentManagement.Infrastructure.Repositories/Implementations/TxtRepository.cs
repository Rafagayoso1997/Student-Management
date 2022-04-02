using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repositories.Contracts
{
    public class TxtRepository : IRepository
    {
        public List<Student> GetAllStudents(string path)
        {
            return File.ReadAllLines(path)
                    .Select(line => Utils.mapStudentFromTextToList(line))
                    .ToList();
        }

        public Student GetStudentById(int id, string path)
        {
            return GetAllStudents(path).Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveStudent(Student student, string path)
        {
            List<Student> students = GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            students.Add(student);

            File.WriteAllLines(path,
                students.Select(st => st.ToString()), Encoding.UTF8);
        }

        public void UpdateStudent(Student student, string path)
        {
            List<Student> students = GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));

            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            int studentindex = students.IndexOf(studentInList);

            students[studentindex] = student;

            File.WriteAllLines(path,
                 students.Select(st => st.ToString()), Encoding.UTF8);
        }

        public void DeleteStudent(Student student, string path)
        {
            List<Student> students = GetAllStudents(path);
            Utils.DeleteIfExist(new FileInfo(path));



            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            students.Remove(studentInList);

            File.WriteAllLines(path,
                 students.Select(st => st.ToString()), Encoding.UTF8);

        }

    }
}
