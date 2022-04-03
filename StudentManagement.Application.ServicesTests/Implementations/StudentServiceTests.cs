using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using StudentManagement.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services.Implementations.Tests
{
    [TestClass()]
    public class StudentServiceTests
    {
        private static StudentService _service;

        private static Mock<IRepositoryFactory> mockRepositoryFactory;
        private static string path = @"C:\Users\Rafael Gayoso\OneDrive\Escritorio\students.json";

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {

            mockRepositoryFactory = new Mock<IRepositoryFactory>();

            mockRepositoryFactory.Setup(repositoryFactory => repositoryFactory.CreateRepository()).Returns(new JsonRepository());

            _service = new StudentService(mockRepositoryFactory.Object);
        }


        [TestMethod()]
        public void GetAllStudentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStudentByIdTest()
        {
            Student student = _service.GetStudentById(2, path);

            Student expectedStudent = new Student()
            {
                Id = 2,
                Name = "Luis",
                Surname = "Luis",
                BirthDate = DateTime.Parse("02/05/1997"),
                Age = 25

            };

            Assert.AreEqual(expectedStudent, student);
        }

        [TestMethod()]
        public void SaveStudentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetIRepositoryFactoryTest()
        {
            Assert.Fail();
        }
    }
}