using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Domain.Entities.Products;
using ETicaretAPI.Domain.Entities.Orders;
using ETicaretAPI.Domain.Entities.Customers;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen veriyi yakalayıp kayıt edildiyse createdDate i, güncellendiyse updatedDate i eklemesini sağlayacaktır.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity<Guid>>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
