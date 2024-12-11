using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Event.Domain.Entities;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class VenueRepository(EventDbContext eventDbContext) : IVenueRepository
    {
        DbSet<Domain.Entities.Venue> DbSet => eventDbContext.Set<Domain.Entities.Venue>();

        public Venue Create(Venue venue)
        {
            DbSet.Add(venue);
            return venue;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var venue = await DbSet.FindAsync(id, cancellationToken);
            DbSet.Remove(venue!);
        }

        public async Task<IList<Domain.Entities.Venue>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync();
        }
    }
}
