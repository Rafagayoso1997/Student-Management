using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Factories.Contracts
{
    public class FileRepositoryFactory : IAbstractRepositoryFactory
    {
       
        public IRepository CreateRepository(Factory Factory)
        {
          
            string format = Enum.GetName(typeof(Factory), Factory);
            string namespac = $"StudentManagement.Infrastructure.Repositories.Implementations.{format}Repository," +
                $" StudentManagement.Infrastructure.Repositories";
            Type type = Type.GetType(namespac);
             
            return (IRepository)Activator.
                CreateInstance(type);
        }
           
    }
}
