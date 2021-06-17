using Investz.Certificates;
using Investz.Interfaces;
using Investz.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Investz.Services
{
    public class TokenService : ITokenService
    {
        private readonly SigningAudienceCertificate signingAudienceCertificate;
        private IUserService userService;

        public TokenService(IUserService userService)
        {
            this.userService = userService;
            signingAudienceCertificate = new SigningAudienceCertificate();
        }

        public async Task<string> GetToken(string username)
        {
            User user = await userService.GetUser(username);
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(User user)
        {
            const int expiringDays = 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.Claims()),
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
