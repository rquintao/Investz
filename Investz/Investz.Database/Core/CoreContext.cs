using Investz.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Investz.Database.Core
{
    public class CoreContext : DbContext, ICoreContext
    {
        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\Rafael\Desktop\Projects\Investz\db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity => {
                entity.HasKey(c => c.Id);
                entity.Property(p => p.Username).IsRequired();
                entity.Property(p => p.Password).IsRequired();
            });
        }
    }
}
