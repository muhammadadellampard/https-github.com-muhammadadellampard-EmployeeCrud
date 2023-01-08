using EmployeeCrud.Core.Repositories;
using EmployeeCrud.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }

        Task<int> Save();
    }
}
