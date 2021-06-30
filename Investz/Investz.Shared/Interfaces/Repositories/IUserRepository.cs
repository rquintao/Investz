using Investz.Data.Entities;
using System.Threading.Tasks;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public Task<UserEntity> GetUser(string username);
    }
}