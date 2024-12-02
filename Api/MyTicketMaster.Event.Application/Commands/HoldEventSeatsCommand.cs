using MediatR;
using MyTicketMaster.Event.Contracts.Types;

namespace MyTicketMaster.Event.Application.Commands
{
    public record HoldEventSeatsCommand(IList<SeatId> SeatIds) : IRequest;
}
