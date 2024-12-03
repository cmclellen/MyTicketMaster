using Microsoft.EntityFrameworkCore;

namespace MyTicketMaster.Event.Persistence
{
    public class EventDbContext : DbContext
    {
        public required DbSet<Domain.Entities.Event> Events { get; set; }
        public required DbSet<Domain.Entities.Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EventDB;Trusted_Connection=True;");
        }
    }
}
