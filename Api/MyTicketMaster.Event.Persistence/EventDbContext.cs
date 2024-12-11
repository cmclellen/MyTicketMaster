using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Event.Domain.Entities;
using System.Reflection.Emit;

namespace MyTicketMaster.Event.Persistence
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Entities.Event> Events { get; set; } = null!;
        public DbSet<Venue> Venues { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            Seed(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var OPTUS_STADIUM = new Guid("23D2DA3B-C620-498E-B5CF-1A20A383CFF7");
            var MT_DUNEED_ESTATE = new Guid("C04E75FF-BBE5-4221-9651-D25EA06F1375");
            var venues = new Domain.Entities.Venue[]
            {
                Domain.Entities.Venue.Create(OPTUS_STADIUM, "Optus Stadium"),
                Domain.Entities.Venue.Create(new Guid("5F7C5002-FF20-4351-8D5E-4E7EB91A1BEA"), "Fremantle Prison"),
                Domain.Entities.Venue.Create(new Guid("7225DCB0-530F-4054-9188-6A308D981499"), "Burswood Park"),
                Domain.Entities.Venue.Create(MT_DUNEED_ESTATE, "Mt Duneed Estate")
            };
            modelBuilder.Entity<Domain.Entities.Venue>().HasData(venues);

            var events = new Domain.Entities.Event[] {
                Domain.Entities.Event.Create(new Guid("7888E967-AF2A-4B81-B971-034C003835FA"), "MJ the Musical", OPTUS_STADIUM),
                Domain.Entities.Event.Create(new Guid("64379420-5DA1-425E-AEB2-DA3D92217528"), "Beauty and the Beast", MT_DUNEED_ESTATE)
            };
            modelBuilder.Entity<Domain.Entities.Event>().HasData(events);
        }
    }
}
