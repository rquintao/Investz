using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Interfaces
{
    public interface ITokenService
    {
        public Task<ResponseSingleDto<string>> GetToken(string username);
    }
}
