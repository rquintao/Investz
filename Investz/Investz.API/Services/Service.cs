using Investz.Shared.Entities;
using Investz.Shared.Interfaces.Repositories;
using Investz.Shared.Models;
using System.Threading.Tasks;

namespace Investz.Services
{
    public abstract class Service<TEntity, TDto> : IService<TEntity> where TEntity : BaseEntity
    {
        public readonly IRepository<TEntity> repo;

        public Service(IRepository<TEntity> repo)
        {
            this.repo = repo;
        }

        public async Task<ResponseSingleDto<TEntity>> GetById(int id)
        {
            ResponseSingleDto<TEntity> dtoOut = new();

            TEntity ent = await repo.GetById(id);

            if (ent != null) 
            {
                dtoOut.Entity = ent;
            }

            return dtoOut;
        }

    }
}
