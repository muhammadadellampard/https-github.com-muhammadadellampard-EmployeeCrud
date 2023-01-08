using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Core.Services
{
    public interface ITokenHandlerService
    {
        Task<Object> GetToken(string userId);
    }
}
