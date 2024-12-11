using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class EventRepository(EventDbContext eventDbContext) : IEventRepository
    {
        private DbSet<Domain.Entities.Event> DbSet => eventDbContext.Set<Domain.Entities.Event>();

        public Domain.Entities.Event Create(Domain.Entities.Event eventItem)
        {
            DbSet.Add(eventItem);
            return eventItem;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventItem = await DbSet.FindAsync(id, cancellationToken);
            DbSet.Remove(eventItem!);
        }

        public async Task<IList<Domain.Entities.Event>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(e=>e.Venue)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Event?> GetByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return await DbSet.Include(e=>e.Venue).FirstOrDefaultAsync(e=>e.Id == eventId);
        }

        public void Update(Domain.Entities.Event eventItem)
        {
            eventDbContext.Entry(eventItem).State = EntityState.Modified;
        }
    }
}
