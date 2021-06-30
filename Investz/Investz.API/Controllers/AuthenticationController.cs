using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Models;
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
        public async Task<ResponseSingleDto<string>> Authenticate([FromBody] UserCredentialsDto userCredentials)
        {
            try
            {
                ResponseSingleDto<string> token = await authenticationService.Authenticate(userCredentials);
                return token;
            }
            catch (InvalidLoginException e)
            {
                return new ResponseSingleDto<string>(e);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ResponseSingleDto<string> Validate()
        {
            return new ResponseSingleDto<string>();
        }
    }
}
