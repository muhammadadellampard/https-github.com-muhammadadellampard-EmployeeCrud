using EmployeeCrud.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Infrastructure.DBContext
{
        public class ApplicationContext : IdentityDbContext
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
            {

            }

            public DbSet<Employee> Emplyees { get; set; }
        }
    }
