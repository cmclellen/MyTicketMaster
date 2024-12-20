﻿using MediatR;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Contracts.Events;

namespace MyTicketMaster.Event.Application.Queries
{
    public record GetEventSeatsQuery : IRequest<PagedResponse<EventSeatResponse>>;

    public class GetEventSeatsQueryHandler : IRequestHandler<GetEventSeatsQuery, PagedResponse<EventSeatResponse>>
    {
        public async Task<PagedResponse<EventSeatResponse>> Handle(GetEventSeatsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var eventSeatResponse = new EventSeatResponse(Guid.NewGuid(), SeatAvailabilityStatusType.Available);
            return new PagedResponse<EventSeatResponse>([eventSeatResponse]);
        }
    }
}
