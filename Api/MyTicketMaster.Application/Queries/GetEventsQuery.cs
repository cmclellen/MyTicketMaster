using MediatR;
using MyTicketMaster.Common.Events;
using MyTicketMaster.Contracts.Common;

namespace MyTicketMaster.Application.Queries
{
    public class GetEventsQuery : IRequest<PagedResponse<EventResponse>>
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, PagedResponse<EventResponse>>
    {
        public async Task<PagedResponse<EventResponse>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new PagedResponse<EventResponse>([new EventResponse("Coldplay")]);
        }
    }
}
