namespace MyTicketMaster.Event.Domain.Repositories
{
    public interface IEventRepository 
    {
        IList<Entities.Event> GetAll();
    }
}
