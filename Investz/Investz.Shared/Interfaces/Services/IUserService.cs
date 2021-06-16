using Investz.Models;
using System.Collections.Generic;

namespace Investz.Interfaces
{
    public interface IUserService
    {
        public void ValidateCredentials(UserCredentials userCredentials);

        public User GetUser(string username);
    }
}
