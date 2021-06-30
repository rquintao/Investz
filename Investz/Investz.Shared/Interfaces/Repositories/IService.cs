using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Shared.Interfaces.Repositories
{
    public interface IService<TEntity>
    {
        Task<ResponseSingleDto<TEntity>> GetById(int id);
    }
}
