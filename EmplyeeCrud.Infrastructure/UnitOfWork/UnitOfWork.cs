using EmployeeCrud.Core.Repositories;
using EmployeeCrud.Core.UnitOfWork;
using EmplyeeCrud.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        public IEmployeeRepository Employee { get; }

        public UnitOfWork(ApplicationContext dbContext,
                            IEmployeeRepository Employee)
        {
            _dbContext = dbContext;
            this.Employee = Employee;
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
