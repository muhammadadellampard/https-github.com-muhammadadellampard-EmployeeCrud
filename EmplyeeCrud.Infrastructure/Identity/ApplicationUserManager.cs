using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmplyeeCrud.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EmplyeeCrud.Infrastructure.Identity
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        private UserStore<IdentityUser, IdentityRole, ApplicationContext, string, IdentityUserClaim<string>
            , IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>
            , IdentityRoleClaim<string>>
            _store;

        public ApplicationUserManager(IUserStore<IdentityUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<IdentityUser> passwordHasher, IEnumerable<IUserValidator<IdentityUser>> userValidators, IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<IdentityUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        private ApplicationContext GetContext()
        {
            _store = (UserStore<IdentityUser, IdentityRole, ApplicationContext, string, IdentityUserClaim<string>,
                    IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>)Store;

            var context = _store.Context;
            return context;
        }


        public async Task<IdentityUser> FindByAnyAsync(string name)
        {
            var context = GetContext();

            return await context.Users.FirstOrDefaultAsync(x => (x.NormalizedUserName == name.ToUpper() || x.NormalizedEmail == name.ToUpper())
            );
        }
        public async Task<IdentityUser> GetUserByIdAsync(string Id)
        {
            var context = GetContext();
            return await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<bool> UserIsExist(string Id)
        {
            var context = GetContext();
            return await context.Users.AnyAsync(x => x.Id == Id);
        }
        public async Task<string> GetUserNameByIdAsync(string Id)
        {
            var context = GetContext();
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return user?.UserName;
        }

    }
}
