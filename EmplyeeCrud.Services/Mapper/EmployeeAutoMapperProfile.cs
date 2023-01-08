using AutoMapper;
using EmployeeCrud.Core.DTO;
using EmployeeCrud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Services.Mapper
{
    public class EmployeeAutoMapperProfile : Profile
    {
        public EmployeeAutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
