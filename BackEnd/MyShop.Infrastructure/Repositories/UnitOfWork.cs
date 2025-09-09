using Microsoft.EntityFrameworkCore;
using MyShop.Domain.BaseEntities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync()
        {
            UpdateTimestamps();
            return await context.SaveChangesAsync();
        }

        private void UpdateTimestamps()
        {
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is DbEntity && 
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (DbEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.UtcNow;

                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
