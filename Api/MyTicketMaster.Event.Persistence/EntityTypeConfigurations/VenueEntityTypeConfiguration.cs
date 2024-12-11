using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTicketMaster.Event.Persistence.EntityTypeConfigurations
{
    public class VenueEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Venue>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Venue> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.CreatedAtUtc).HasDefaultValueSql("getutcdate()");
            builder.Property(c => c.ModifiedAtUtc).HasDefaultValueSql("getutcdate()");
        }
    }
}
