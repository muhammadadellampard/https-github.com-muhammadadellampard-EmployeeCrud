using EmployeeCrud.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Core.Services
{
    public interface IAuthenticateService
    {
        Task<object> Login(LoginDTO model);
        Task<bool> Logut(string userId);
    }
}
