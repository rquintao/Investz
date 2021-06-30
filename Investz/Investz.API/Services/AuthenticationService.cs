using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserService userService;

        private readonly ITokenService tokenService;

        public AuthenticationService(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public async Task<ResponseSingleDto<string>> Authenticate(UserCredentialsDto userCredentials)
        {
            await userService.ValidateCredentials(userCredentials);
            string securityToken = await tokenService.GetToken(userCredentials.Username);

            return new ResponseSingleDto<string>() { Entity = securityToken };
        }
    }
}
