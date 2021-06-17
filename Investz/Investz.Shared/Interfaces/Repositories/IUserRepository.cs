using Investz.Models;
using System.Threading.Tasks;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string username);
    }
}
