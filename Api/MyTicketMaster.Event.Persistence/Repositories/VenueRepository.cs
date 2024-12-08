using MyTicketMaster.Event.Domain.Entities;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Persistence.Repositories
{
    public class VenueRepository(EventDbContext eventDbContext) : IVenueRepository
    {
        public Venue Create(Venue venue)
        {
            var set = eventDbContext.Set<Domain.Entities.Venue>();
            set.Add(venue);
            return venue;
        }

        public IList<Domain.Entities.Venue> GetAll()
        {
            return eventDbContext.Set<Domain.Entities.Venue>().ToList();
        }
    }
}
