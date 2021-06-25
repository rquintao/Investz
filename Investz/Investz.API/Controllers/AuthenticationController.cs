using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Investz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentialsDto userCredentials)
        {
            try
            {
                string token = await authenticationService.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (InvalidLoginException)
            {
                return Unauthorized();
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}
