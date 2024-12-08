namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IVenueRepository
    {
        IList<Entities.Venue> GetAll();
        Entities.Venue Create(Entities.Venue venue);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
