using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Interfaces.Repositories;
using System.Collections.Generic;

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

        public User GetUser(string username)
        {
            return userRepository.GetUser(username);
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = GetUser(userCredentials.Username);


            if (user.Username != userCredentials.Username || user.Password != userCredentials.Password)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}
