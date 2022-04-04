using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StudentManagement.Infrastructure.Repositories.Contracts
{
    public class XmlRepository : IRepository
    {
        public IEnumerable<Student> GetAllStudents(string path)
        {

            var doc = XDocument.Load(path);

            List<Student> students = doc.Root
                .Descendants("Student")
                .Select(node => new Student
                {
                    Id = int.Parse(node.Element("Id").Value),
                    Name = node.Element("Name").Value,
                    Surname = node.Element("Surname").Value,
                    BirthDate = DateTime.Parse(node.Element("BirthDate").Value),
                    Age = int.Parse(node.Element("Age").Value)
                })
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
            FileStream file = File.Create(path);
            XmlSerializer writer =
                new XmlSerializer(typeof(List<Student>));
            Utils.DeleteIfExist(new FileInfo(path));

            students.Add(student);
            if (students.Contains(student))
                inserted = true;

            

            writer.Serialize(file, students);
            
            file.Close();

            return inserted;
        }

        public bool UpdateStudent(Student student, string path)
        {
            bool updated = false;

            List<Student> students = (List<Student>)GetAllStudents(path);

            XmlSerializer writer =
                new XmlSerializer(typeof(List<Student>));
            Utils.DeleteIfExist(new FileInfo(path));

            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            int studentindex = students.IndexOf(studentInList);

            students[studentindex] = student;

            if (students.Contains(student))
                updated = true;

            FileStream file = File.Create(path);

            writer.Serialize(file, students);

            file.Close();
            return updated;
        }

        public bool DeleteStudent(Student student, string path)
        {
            List<Student> students = (List<Student>)GetAllStudents(path);

            XmlSerializer writer =
                new XmlSerializer(typeof(List<Student>));
            Utils.DeleteIfExist(new FileInfo(path));

            Student studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            bool removed = students.Remove(studentInList);
                
            FileStream file = File.Create(path);

            writer.Serialize(file, students);

            file.Close();

            return removed;
        }

    }
}
