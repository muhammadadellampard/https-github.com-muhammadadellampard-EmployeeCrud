using EmployeeCrud.Core.Repositories;
using EmployeeCrud.Core.Services;
using EmployeeCrud.Core.UnitOfWork;
using EmplyeeCrud.Services.Emplyee;
using EmplyeeCrud.Services.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Services
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServicesDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<EmployeeAutoMapperProfile>();
            });

            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
