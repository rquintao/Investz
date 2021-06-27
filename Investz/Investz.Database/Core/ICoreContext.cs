using Investz.Data.Entities;
using Investz.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Investz.Database.Core
{
    public interface ICoreContext : IUnitOfWork
    {
        DbSet<UserEntity> User { get; set; }
    }
}
