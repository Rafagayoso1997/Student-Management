using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagement.Infrastructure.Factories.Contracts;
using StudentManagement.Crosscutting.Models;

using System;

namespace StudentManagement.Application.Services.Implementations.Tests
{
    [TestClass()]
    public class StudentServiceXmlTests
    {
        private static StudentService _service;

        private static string path = @"C:\Users\Rafael Gayoso\OneDrive\Escritorio\students.xml";

        [ClassInitialize]
        public static void AssemblyInit(TestContext context)
        {
            
            _service = new StudentService(new FileRepositoryFactory());
            _service.SetIRepositoryFactory(Factory.Xml);
        }

        [TestMethod()]
        public void GetStudentByIdTest()
        {
            Student student = _service.GetStudentById(2, path);

            Student expectedStudent = new Student()
            {
                Id = 2,
                Name = "Luis",
                Surname = "TEST",
                BirthDate = DateTime.Parse("05/02/1997"),
                Age = 25

            };

            Assert.AreEqual(expectedStudent, student);
        }

        [TestMethod()]
        public void SaveStudentTest()
        {
            Student student = new Student(17,"Rafa","Rafa", DateTime.Now);

            bool result = _service.SaveStudent(student, path);

            bool expectedresult = true;

            Assert.AreEqual(expectedresult, result);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            Student student = new Student(6, "Rafa", "Rafa", DateTime.Now);

            bool result = _service.UpdateStudent(student, path);

            bool expectedresult = true;

            Assert.AreEqual(expectedresult, result);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            Student student = new Student(17, "Rafa", "Rafa", DateTime.Now);

            bool result = _service.DeleteStudent(student, path);

            bool expectedresult = true;

            Assert.AreEqual(expectedresult, result);
        }

      
    }
}