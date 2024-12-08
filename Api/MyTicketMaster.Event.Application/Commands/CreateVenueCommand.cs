using MediatR;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Commands
{
    public record CreateVenueCommand(string Name) : IRequest;

    public class CreateVenueCommandHandler(IVenueRepository venueRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateVenueCommand>
    {
        public async Task Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            var venue = Domain.Entities.Venue.Create(Guid.NewGuid(), request.Name);
            venueRepository.Create(venue);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
