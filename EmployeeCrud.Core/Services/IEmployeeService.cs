using EmployeeCrud.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Core.Services
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(EmployeeDto EmployeeDetails);

        Task<IEnumerable<EmployeeDto>> GetAllEmployees();

        Task<EmployeeDto> GetEmployeeById(int EmployeeId);

        Task<bool> UpdateEmployee(EmployeeDto EmployeeDetails);

        Task<bool> DeleteEmployee(int EmployeeId);
    }
}
