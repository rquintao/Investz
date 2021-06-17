using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investz.Services
{
    public class UserService : IUserService
    {
        public readonly IEnumerable<UserCredentials> users;

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUser(string username)
        {
            User user = await userRepository.GetUser(username);

            return user;
        }

        public async Task ValidateCredentials(UserCredentials userCredentials)
        {
            User user = await GetUser(userCredentials.Username);


            if (user.Username != userCredentials.Username || user.Password != userCredentials.Password)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}
