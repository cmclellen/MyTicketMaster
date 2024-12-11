namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IVenueRepository
    {
        Task<IList<Entities.Venue>> GetAllAsync(CancellationToken cancellationToken);
        Entities.Venue Create(Entities.Venue venue);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
