using EmployeeCrud.Core.Entities;
using EmployeeCrud.Core.Repositories;
using EmplyeeCrud.Infrastructure.DBContext;
using EmplyeeCrud.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
