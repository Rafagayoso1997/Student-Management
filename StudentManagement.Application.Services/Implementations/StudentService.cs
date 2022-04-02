
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Application.Services.Contracts;
using StudentManagement.Application.Factories.Implementations;
using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentManagement.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {   
        private IRepositoryFactory _repositoryFactory;
        private IRepository _repository;

        public StudentService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _repository = repositoryFactory.CreateRepository();
        }

        public IEnumerable<Student> GetAllStudents(string path)
        {
            IEnumerable<Student> students = null;
            try
            {
                students = _repository.GetAllStudents(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(students == null)
                {
                    students = new List<Student>();
                }
            }

            return students;
            
        }

        public Student GetStudentById(int id, string path)
        {
            return _repository.GetStudentById(id, path);
        }

        public void SaveStudent(Student student, string path)
        {
            if (student.Surname.StartsWith("a"))
            {
                Console.WriteLine("Error");
            }
            _repository.SaveStudent(student, path);
        }

        public void UpdateStudent(Student student, string path)
        {
            _repository.UpdateStudent(student, path);
        }

        public void DeleteStudent(Student student, string path)
        {
            _repository.DeleteStudent(student, path);
        }

        public void SetIRepositoryFactory(Factory factoryType)
        {
            switch (factoryType)
            {
                case Factory.JSON:
                    _repositoryFactory = new JsonRepositoryFactory();
                    break;
                case Factory.XML:
                    _repositoryFactory = new XmlRepositoryFactory();
                    break;
                case Factory.TXT:
                    _repositoryFactory = new TxtRepositoryFactory();
                    break;
            }

            _repository = _repositoryFactory.CreateRepository();

        }
    }
}
