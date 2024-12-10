
namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IEventRepository 
    {
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        IList<Entities.Event> GetAll();
    }
}
