using Investz.Data.Entities;
using Investz.Database.Core;
using Investz.Database.Repositories;
using Investz.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Investz.Data.Repositories
{
    public class UserRepository : Repository<UserEntity, ICoreContext>, IUserRepository
    {

        public UserRepository(ICoreContext coreContext) : base(coreContext)
        {
        }

        public async Task<UserEntity> GetUser(string username)
        {
            return await Context.User.FirstOrDefaultAsync(u => u.Username.Equals(username));
        }
    }
}