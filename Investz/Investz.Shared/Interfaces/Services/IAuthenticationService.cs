using Investz.Models;
using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<ResponseSingleDto<string>> Authenticate(UserCredentialsDto userCredentials);
    }
}
