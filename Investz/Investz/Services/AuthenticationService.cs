using Investz.Interfaces;
using Investz.Models;

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

        public string Authenticate(UserCredentials userCredentials)
        {
            userService.ValidateCredentials(userCredentials);
            string securityToken = tokenService.GetToken(userCredentials.Username);

            return securityToken;
        }
    }
}
