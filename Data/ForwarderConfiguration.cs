using LogisticOrderTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticOrderTracker.Data
{
    public class ForwarderConfiguration : IEntityTypeConfiguration<Forwarder>
    {
        public void Configure(EntityTypeBuilder<Forwarder> builder)
        {
            builder.HasMany(c => c.Contacts);
        }
    }
}