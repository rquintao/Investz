using Investz.Models;
using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface IUserService
    {
        public Task ValidateCredentials(UserCredentialsDto userCredentials);

        public Task<ResponseSingleDto<UserDto>> GetUser(string username);
    }
}
