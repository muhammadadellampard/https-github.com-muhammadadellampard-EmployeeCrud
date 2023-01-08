using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeCrud.Infrastructure.Identity
{
    public class ApplicationSignInManager : SignInManager<IdentityUser>
    {

        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;

        public ApplicationSignInManager(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<IdentityUser>> logger,
            IAuthenticationSchemeProvider schemeProvider,
            IUserConfirmation<IdentityUser> userConfirmation
            )
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider, userConfirmation)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));

            contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }


        public async Task<bool> SignInAsync(string email, string password)
        {
            var target = await userManager.FindByEmailAsync(email);
            if (target == null)
            {
                return false;
            }
            var result = await signInManager.PasswordSignInAsync(target, password, false, false);
            return result.Succeeded;
        }
        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
