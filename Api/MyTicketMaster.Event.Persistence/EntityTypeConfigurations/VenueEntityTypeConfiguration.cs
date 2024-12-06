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

            var venues = new Domain.Entities.Venue[]
            {
                Domain.Entities.Venue.Create(new Guid("23D2DA3B-C620-498E-B5CF-1A20A383CFF7"), "Optus Stadium"),
                Domain.Entities.Venue.Create(new Guid("5F7C5002-FF20-4351-8D5E-4E7EB91A1BEA"), "Fremantle Prison"),
                Domain.Entities.Venue.Create(new Guid("7225DCB0-530F-4054-9188-6A308D981499"), "Burswood Park"),
                Domain.Entities.Venue.Create(new Guid("C04E75FF-BBE5-4221-9651-D25EA06F1375"), "Mt Duneed Estate")
            };
            builder.HasData(venues);
        }
    }
}
