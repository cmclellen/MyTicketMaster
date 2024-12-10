using MediatR;

namespace MyTicketMaster.Event.Application.Commands
{
    public record CreateEventCommand(string Name) : IRequest;
}
