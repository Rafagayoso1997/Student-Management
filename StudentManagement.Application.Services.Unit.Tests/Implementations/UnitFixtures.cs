using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services.Unit.Tests.Implementations
{
    public static class UnitFixtures
    {
        public static Student GetStudentById(int id)
        {
            return new Student()
            {
                Id = 2,
                Name = "Rafa",
                Surname = "Rafa",
                BirthDate = DateTime.Parse("02/05/1997"),
                Age = 25

            };
        }

        public static List<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                    new Student()
                    {
                        Id = 2,
                        Name = "Rafa",
                        Surname = "Rafa",
                        BirthDate = DateTime.Parse("02/05/1997"),
                        Age = 25

                    },
                    new Student()
                    {
                        Id = 3,
                        Name = "Rafa",
                        Surname = "Rafa",
                        BirthDate = DateTime.Parse("02/05/1997"),
                        Age = 25

                    },
                    new Student()
                    {
                        Id = 4,
                        Name = "Rafa",
                        Surname = "Rafa",
                        BirthDate = DateTime.Parse("02/05/1997"),
                        Age = 25

                    },
                    new Student()
                    {
                        Id = 5,
                        Name = "Rafa",
                        Surname = "Rafa",
                        BirthDate = DateTime.Parse("02/05/1997"),
                        Age = 25

                    }
            };
        }

        public static bool SaveStudent(Student student)
        {
           
            var students = GetAllStudents();
            students.Add(student);
            return students.Contains(student);
        }

        public static bool UpdateStudent(Student student)
        {
         

            var students = GetAllStudents();

            var studentInList = students.FirstOrDefault(x => x.Id == student.Id);

            int studentindex = students.IndexOf(studentInList);

            students[studentindex] = student;
     
            return students.Contains(student);
        }

        public static bool DeleteStudent(Student student)
        {


            var students = GetAllStudents();



            return students.Remove(student);
        }
    }
}
