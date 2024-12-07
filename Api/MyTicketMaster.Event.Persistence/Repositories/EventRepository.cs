using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class EventRepository(EventDbContext eventDbContext) : IEventRepository
    {
        public IList<Domain.Entities.Event> GetAll()
        {
            return eventDbContext.Set<Domain.Entities.Event>().ToList();
        }
    }
}
