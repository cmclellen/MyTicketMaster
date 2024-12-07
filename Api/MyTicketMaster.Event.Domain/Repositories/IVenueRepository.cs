namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IVenueRepository
    {
        IList<Entities.Venue> GetAll();
    }
}
