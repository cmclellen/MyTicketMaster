using MediatR;
using MyTicketMaster.Contracts.Common;
using MyTicketMaster.Contracts.Events;

namespace MyTicketMaster.Application.Queries
{
    public record GetEventSeatsQuery : IRequest<PagedResponse<EventSeatResponse>>;

    public class GetEventSeatsQueryHandler : IRequestHandler<GetEventSeatsQuery, PagedResponse<EventSeatResponse>>
    {
        public async Task<PagedResponse<EventSeatResponse>> Handle(GetEventSeatsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var eventSeatResponse = new EventSeatResponse(1, SeatAvailabilityStatusType.Available);
            return new PagedResponse<EventSeatResponse>([eventSeatResponse]);
        }
    }
}
