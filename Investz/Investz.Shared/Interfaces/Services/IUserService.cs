using Investz.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface IUserService
    {
        public Task ValidateCredentials(UserCredentials userCredentials);

        public Task<User> GetUser(string username);
    }
}
