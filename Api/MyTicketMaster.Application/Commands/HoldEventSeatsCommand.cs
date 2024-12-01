using MediatR;
using MyTicketMaster.Contracts.Types;

namespace MyTicketMaster.Application.Commands
{
    public record HoldEventSeatsCommand(IList<SeatId> SeatIds) : IRequest;
}
