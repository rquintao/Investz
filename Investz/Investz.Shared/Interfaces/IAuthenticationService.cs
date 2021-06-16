using Investz.Models;

namespace Investz.Interfaces
{
    public interface IAuthenticationService
    {
        public string Authenticate(UserCredentials userCredentials);
    }
}
