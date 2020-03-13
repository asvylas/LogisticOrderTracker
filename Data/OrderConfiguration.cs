using LogisticOrderTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticOrderTracker.Data
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(c => c.Shipments);
            builder.HasOne(c => c.Receiver);
            builder.HasOne(c => c.Sender);
            builder.HasOne(c => c.ProductManager);
            builder.HasOne(c => c.Forwarder);
            builder.HasOne(c => c.ProductManager);
        }
    }
}