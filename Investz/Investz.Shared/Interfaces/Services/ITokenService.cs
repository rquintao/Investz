using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetToken(string username);
    }
}
