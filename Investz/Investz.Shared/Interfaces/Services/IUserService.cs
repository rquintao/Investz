using Investz.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface IUserService
    {
        public Task ValidateCredentials(UserCredentialsDto userCredentials);

        public Task<UserDto> GetUser(string username);
    }
}
