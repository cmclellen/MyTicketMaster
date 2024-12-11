

namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IEventRepository 
    {
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Entities.Event Create(Entities.Event eventItem);
        Task<IList<Entities.Event>> GetAllAsync(CancellationToken cancellationToken);
        Task<Entities.Event?> GetByIdAsync(Guid eventId, CancellationToken cancellationToken);
        void Update(Domain.Entities.Event eventItem);
    }
}
