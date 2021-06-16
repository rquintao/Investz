using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using System.Collections.Generic;
using System.Linq;

namespace Investz.Services
{
    public class UserService : IUserService
    {
        public readonly IEnumerable<UserCredentials> users;

        public UserService()
        {
            users = new List<UserCredentials>
        {
            new UserCredentials
            {
                Username = "john.doe",
                Password = "john.password"
            }
        };
        }

        public User GetUser()
        {
            return new User()
            {
                Username = "john.doe",
                Password = "john.password",
                Roles = new List<string>() { "admin" }
            };
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = GetUser();


            if (user.Username != userCredentials.Username || user.Password != userCredentials.Password)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}
