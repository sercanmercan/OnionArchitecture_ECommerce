using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity<Guid>
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
           EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(T model)
        {
            model.IsDeleted = true;
            model.DeletedDate = DateTime.Now;
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            model.IsDeleted = true;
            model.DeletedDate = DateTime.Now;
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public bool RemoveRangeAsync(List<T> datas)
        {
            datas.ForEach(x =>
            {
                x.IsDeleted = true;
                x.DeletedDate = DateTime.Now;
            });
            Table.UpdateRange(datas);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public bool UpdateRange(List<T> model)
        {
            Table.UpdateRange(model);
            return true;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
