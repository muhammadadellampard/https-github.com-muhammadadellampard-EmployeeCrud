using EmployeeCrud.Core.Repositories;
using EmployeeCrud.Core.UnitOfWork;
using EmplyeeCrud.Infrastructure.DBContext;
using EmplyeeCrud.Infrastructure.Repositories;
using EmplyeeCrud.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, EmplyeeCrud.Infrastructure.UnitOfWork.UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
