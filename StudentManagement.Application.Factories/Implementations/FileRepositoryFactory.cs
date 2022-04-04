using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
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
            //switch (Factory)
            //{
            //    case Factory.JSON:
            //        _repository =  new JsonRepository();
            //        break;
            //    case Factory.XML:
            //        _repository = new XmlRepository();
            //        break;
            //    case Factory.TXT:
            //        _repository = new TxtRepository();
            //        break; 
            //}
            
          
            string format = Enum.GetName(typeof(Factory), Factory);
            string namespac = $"StudentManagement.Infrastructure.Repositories.Implementations.{format}Repository, StudentManagement.Infrastructure.Repositories";
            Type type = Type.GetType(namespac);
             _repository = (IRepository)Activator.
                CreateInstance(type);
            return _repository;
        }
           
    }
}
