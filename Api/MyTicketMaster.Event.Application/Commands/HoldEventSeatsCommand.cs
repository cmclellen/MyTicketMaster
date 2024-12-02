using MediatR;
using MyTicketMaster.Event.Contracts.Types;

namespace MyTicketMaster.Event.Application.Commands
{
    public record HoldEventSeatsCommand(EventId EventId, IList<SeatId> SeatIds) : IRequest;

    public class HoldEventSeatsCommandHandler : IRequestHandler<HoldEventSeatsCommand>
    {
        public Task Handle(HoldEventSeatsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
