using EmployeeCrud.Core.DTO;
using EmployeeCrud.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmplyeeCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticateController(
            IAuthenticateService authenticateService
            )
        {
            this.authenticateService = authenticateService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Object>> Login([FromBody] LoginDTO model)
        {
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await authenticateService.Login(model));
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        [Authorize]
        public async Task<ActionResult<bool>> Logout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await authenticateService.Logut(userId));
        }

        }

    }
