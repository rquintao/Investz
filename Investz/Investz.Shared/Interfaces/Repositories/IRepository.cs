using System.Threading.Tasks;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
    }
}
