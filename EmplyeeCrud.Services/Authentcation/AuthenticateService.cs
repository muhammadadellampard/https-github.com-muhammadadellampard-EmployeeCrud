using EmployeeCrud.Core.AppSettings;
using EmployeeCrud.Core.DTO;
using EmployeeCrud.Core.Services;
using EmployeeCrud.Core.UnitOfWork;
using EmplyeeCrud.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Services.Authentcation
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationSignInManager signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenHandlerService tokenHandler;
        public AuthenticateService(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            IUnitOfWork unitOfWork,
            ITokenHandlerService tokenHandler
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.tokenHandler = tokenHandler;
        }

        public async Task<object> Login(LoginDTO model)
        {
            var user = await userManager.GetUserByIdAsync(model.UserId);
            if (user == null)
                throw new Exception("user Not found");

            var result = await signInManager.SignInAsync(user.Email, model.Password);
            if (user == null || !result)
                throw new Exception("User Login Data Not Correct");

            var token = await tokenHandler.GetToken(user.Id);
            return token;
        }

        public async Task<bool> Logut(string userId)
        {
            var user = await userManager.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("user Not found");

            await signInManager.SignOutAsync();
            return true;
        }
    }
    }
