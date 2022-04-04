using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using StudentManagement.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Factories.Contracts
{
    public class FileRepositoryFactory : IAbstractRepositoryFactory
    {
        private IRepository _repository;
        public IRepository CreateRepository(Factory Factory)
        {
            switch (Factory)
            {
                case Factory.JSON:
                    _repository =  new JsonRepository();
                    break;
                case Factory.XML:
                    _repository = new XmlRepository();
                    break;
                case Factory.TXT:
                    _repository = new TxtRepository();
                    break; 
            }

            return _repository;
        }
    }
}
