using EmployeeCrud.Core.AppSettings;
using EmployeeCrud.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EmplyeeCrud.Infrastructure.Identity
{
    public class TokenHondlerService : ITokenHandlerService
    {
        private readonly IConfiguration settings;
        private readonly ApplicationUserManager applicationUserManager;

        public TokenHondlerService(
            IConfiguration settings
            , ApplicationUserManager applicationUserManager)
        {
            this.settings = settings;
            this.applicationUserManager = applicationUserManager;
        }
        public async Task<Object> GetToken(string userId)
        {

            var user = await applicationUserManager.FindByIdAsync(userId);

            var jsonUser = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.None,
                                        new JsonSerializerSettings
                                        {
                                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                        });

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                          {
                        new Claim("User",jsonUser),
                        new Claim("UserId",user.Id.ToString()),
                        new Claim("Email",user.Email.ToString()),
                        new Claim("UserName",user.UserName.ToString())
                          }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings["JWT:SecretKey"])),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
