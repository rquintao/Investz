using Investz.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> Authenticate(UserCredentials userCredentials);
    }
}
