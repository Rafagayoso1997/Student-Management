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
        public List<Student> GetAllStudents(string path)
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

           
          return students;
           
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
