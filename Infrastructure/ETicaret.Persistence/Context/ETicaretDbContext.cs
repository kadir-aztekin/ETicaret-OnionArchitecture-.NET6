using ETicaret.Domain.Entites;
using ETicaret.Domain.Entites.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Context
{
    public class ETicaretDbContext : DbContext
    {
        public ETicaretDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan degısıklerın yada yeni eklenen verinin yakalanması saglayan propdır
            //Track edilen verileri yakalayıp elde etmemızı saglar
            var datas= ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var result = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
