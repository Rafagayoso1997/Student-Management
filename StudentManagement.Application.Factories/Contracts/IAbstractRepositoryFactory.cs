using StudentManagement.Crosscutting.Models;
using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Factories.Contracts
{
    public interface IAbstractRepositoryFactory
    {
        IRepository CreateRepository(Factory Factory);
    }
}
