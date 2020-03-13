using LogisticOrderTracker.Data;
using LogisticOrderTracker.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogisticOrderTracker.Models
{
    public class LogisticOrderTrackerContext : DbContext
    {
        public LogisticOrderTrackerContext(DbContextOptions<LogisticOrderTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<LogisticOrderTracker.Models.Address> Address { get; set; }

        public DbSet<LogisticOrderTracker.Models.AddressContact> AddressContact { get; set; }

        public DbSet<LogisticOrderTracker.Models.ForwarderContact> ForwarderContact { get; set; }

        public DbSet<LogisticOrderTracker.Models.Forwarder> Forwarder { get; set; }

        public DbSet<LogisticOrderTracker.Models.Shipment> Shipment { get; set; }

        public DbSet<LogisticOrderTracker.Models.Package> Package { get; set; }

        public DbSet<LogisticOrderTracker.Models.ProductManager> ProductManager { get; set; }

        public DbSet<LogisticOrderTracker.Models.Order> Order { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity is Base && (entry.State == EntityState.Added || entry.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Base)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Base)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ForwarderConfiguration());
        }
    }
}