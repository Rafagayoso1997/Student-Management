﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagement.Application.Services.Implementations;
using StudentManagement.Application.Services.Unit.Tests.Implementations;
using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services.Implementations.Tests
{
    [TestClass()]
    public class StudentServiceTests
    {
        private static StudentService _service;

        private static Mock<IRepository> mockRepository;

        private static string path = @"C:\Users\Rafael Gayoso\OneDrive\Escritorio\students.json";

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            mockRepository = new Mock<IRepository>();



            mockRepository.Setup(repository => repository.GetStudentById(2, "")).Returns(UnitFixtures.GetStudentById(2));
            mockRepository.Setup(repository => repository.GetAllStudents("")).Returns(UnitFixtures.GetAllStudents());
            mockRepository.Setup(repository => repository.SaveStudent(new Student(1, "Rafa", "Rafa", DateTime.Now), ""))
                .Returns(UnitFixtures.SaveStudent(new Student(1,"Rafa","Rafa", DateTime.Now)));

            mockRepository.Setup(repository => repository.UpdateStudent(new Student(3, "Rafa", "Rafa", DateTime.Now), ""))
                .Returns(UnitFixtures.UpdateStudent(new Student(3, "Rafa", "Rafa", DateTime.Now)));

            mockRepository.Setup(repository => repository.DeleteStudent(new Student(2, "Rafa", "Rafa", DateTime.Parse("02/05/1997")), ""))
                .Returns(UnitFixtures.UpdateStudent(new Student(2, "Rafa", "Rafa", DateTime.Parse("02/05/1997"))));

            _service = new StudentService(mockRepository.Object);
        }


        [TestMethod()]
        public void GetAllStudentsTest()
        {
            int studentCount = _service.GetAllStudents("").Count();

            int expectedStudents = 4;

            Assert.AreEqual(expectedStudents, studentCount);
        }

        [TestMethod()]
        public void GetStudentByIdTest()
        {
            Student student = _service.GetStudentById(2, "");

            Student expectedStudent = new Student()
            {
                Id = 2,
                Name = "Rafa",
                Surname = "Rafa",
                BirthDate = DateTime.Parse("02/05/1997"),
                Age = 25

            };

            Assert.AreEqual(expectedStudent, student);
        }

        [TestMethod()]
        public void SaveStudentTest()
        {
            bool insertedStudent = _service.SaveStudent(new Student(1, "Rafa", "Rafa", DateTime.Now), "");

            bool expetedresult = true;
            Assert.AreEqual(expetedresult, insertedStudent);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            bool updatedStudent = _service.UpdateStudent(new Student(3, "Rafa", "Rafa", DateTime.Now), "");

            bool expetedresult = true;
            Assert.AreEqual(expetedresult, updatedStudent);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            bool deletedStudent = _service.DeleteStudent(new Student(2, "Rafa", "Rafa", DateTime.Parse("02/05/1997")), "");

            bool expetedresult = true;
            Assert.AreEqual(expetedresult, deletedStudent);
        }

    }
}