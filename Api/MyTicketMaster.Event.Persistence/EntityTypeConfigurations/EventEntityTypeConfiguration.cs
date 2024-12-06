using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTicketMaster.Event.Persistence.EntityTypeConfigurations
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Event>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Event> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.CreatedAtUtc).HasDefaultValueSql("getutcdate()");
            builder.Property(c => c.ModifiedAtUtc).HasDefaultValueSql("getutcdate()");

            var events = new Domain.Entities.Event[] {
                Domain.Entities.Event.Create(new Guid("7888E967-AF2A-4B81-B971-034C003835FA"), "MJ the Musical"),
                Domain.Entities.Event.Create(new Guid("64379420-5DA1-425E-AEB2-DA3D92217528"), "Beauty and the Beast")
            };
            builder.HasData(events);
        }
    }
}
