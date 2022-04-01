
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

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _repository.GetStudentById(id);
        }

        public void SaveStudent(Student student)
        {
            _repository.SaveStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            _repository.DeleteStudent(student);
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
