using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Infrastructure.Repositories;
using StudentManagement.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Factories.Implementations
{
    public class XmlRepositoryFactory : IRepositoryFactory
    {
        public IRepository CreateRepository()
        {
           return new XmlRepository();
        }
    }
}
