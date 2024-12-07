using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class VenueRepository(EventDbContext eventDbContext) : IVenueRepository
    {
        public IList<Domain.Entities.Venue> GetAll()
        {
            return eventDbContext.Set<Domain.Entities.Venue>().ToList();
        }
    }
}
