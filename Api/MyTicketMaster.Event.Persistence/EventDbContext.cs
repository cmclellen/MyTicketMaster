using Microsoft.EntityFrameworkCore;

namespace MyTicketMaster.Event.Persistence
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
            
        }

        //public required DbSet<Domain.Entities.Event> Events { get; set; }
        public DbSet<Domain.Entities.Venue> Venues { get; set; } = null!;
    }
}
