using Investz.Data.Entities;
using Investz.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Investz.Data.Repositories
{
    public class UserRepository : DbContext, IUserRepository
    {
        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\CTW00766\Desktop\Stuff\Investz\db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserEntity>(entity => {
                entity.HasKey(c => c.Id);
                entity.Property(p => p.Username).IsRequired();
                entity.Property(p => p.Password).IsRequired();
            });
        }

        public Task<UserEntity> GetUser(string username)
        {
            return Task.FromResult(User.SingleOrDefault(u => u.Username.Equals(username)));
        }
    }
}