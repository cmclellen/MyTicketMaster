
namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IEventRepository 
    {
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Entities.Event Create(Entities.Event eventItem);
        IList<Entities.Event> GetAll();
    }
}
