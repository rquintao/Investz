using Investz.Shared.Entities;
using System.Threading.Tasks;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
    }
}
