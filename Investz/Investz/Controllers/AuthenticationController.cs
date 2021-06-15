using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Investz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string token = authenticationService.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (InvalidLoginException)
            {
                return Unauthorized();
            }
        }
    }
}
