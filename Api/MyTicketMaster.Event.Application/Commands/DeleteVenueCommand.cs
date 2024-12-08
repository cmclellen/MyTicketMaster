using MediatR;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Commands
{
    public record DeleteVenueCommand(Guid Id) : IRequest;

    public class DeleteVenueCommandHandler(IVenueRepository venueRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteVenueCommand>
    {
        public async Task Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
        {
            await venueRepository.DeleteAsync(request.Id, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
