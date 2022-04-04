﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using StudentManagement.Infrastructure.Repositories.Implementations;
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

        private static string path = @"C:\Users\Rafael Gayoso\OneDrive\Escritorio\students.json";

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _service = new StudentService(new JsonRepository());
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
                BirthDate = DateTime.Parse("02/05/1997"),
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