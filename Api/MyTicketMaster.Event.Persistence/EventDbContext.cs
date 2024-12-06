using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Event.Domain.Entities;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
