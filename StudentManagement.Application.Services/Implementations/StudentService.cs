
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Application.Services.Contracts;
using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Abstractions;

namespace StudentManagement.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {   
        private readonly IAbstractRepositoryFactory _repositoryFactory;
        private IRepository _repository;
        private readonly IFileSystem _fileSystem;

        public StudentService(IAbstractRepositoryFactory repositoryFactory, IFileSystem fileSystem)
        {
            _repositoryFactory = repositoryFactory;
            _repository = repositoryFactory.CreateRepository(Factory.JSON);
            _fileSystem = fileSystem;
        }

        public StudentService(IRepository repository)
        {
            
            _repository = repository;
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

        public bool SaveStudent(Student student, string path)
        {
           return _repository.SaveStudent(student, path);
        }

        public bool UpdateStudent(Student student, string path)
        {
            return _repository.UpdateStudent(student, path);
        }

        public bool DeleteStudent(Student student, string path)
        {
            return _repository.DeleteStudent(student, path);
        }

        public void SetIRepositoryFactory(Factory factoryType)
        {

            _repository = _repositoryFactory.CreateRepository(factoryType);

        }
    }
}
