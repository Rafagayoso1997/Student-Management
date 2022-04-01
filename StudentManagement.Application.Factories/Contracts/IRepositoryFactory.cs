using StudentManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Factories.Contracts
{
    public interface IRepositoryFactory
    {
        IRepository CreateRepository();
    }
}
