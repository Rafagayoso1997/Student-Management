﻿using StudentManagement.Crosscutting.Models;
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
            //<Student> students = Utils.mapStudentFromTextToList(lines);
             
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
