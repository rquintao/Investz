using Investz.Shared.Entities;
using Investz.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Investz.Database.Repositories
{
    public abstract class Repository<TEntity, TRepository> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext dbContext;

        protected readonly IUnitOfWork unitOfWork;

        public Repository() { }

        public Repository(IUnitOfWork unitOfWork){
            dbContext = (DbContext)unitOfWork;
            this.unitOfWork = unitOfWork;
        }

        protected DbSet<TEntity> DbSet
        {
            get {
                return this.dbContext.Set<TEntity>();
            }
        }

        public TRepository Context
        {
            get { return (TRepository)this.unitOfWork; }
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(ele => ele.Id == id);
        }
    }
}
