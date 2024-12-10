using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class EventRepository(EventDbContext eventDbContext) : IEventRepository
    {
        private DbSet<Domain.Entities.Event> DbSet => eventDbContext.Set<Domain.Entities.Event>();

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventItem = await DbSet.FindAsync(id, cancellationToken);
            DbSet.Remove(eventItem!);
        }

        public IList<Domain.Entities.Event> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
