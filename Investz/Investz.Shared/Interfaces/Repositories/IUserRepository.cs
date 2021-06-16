using Investz.Models;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User GetUser(string username);
    }
}
