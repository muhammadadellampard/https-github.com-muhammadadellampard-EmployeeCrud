using EmployeeCrud.Core.Entities;
using EmployeeCrud.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Core.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }
}
