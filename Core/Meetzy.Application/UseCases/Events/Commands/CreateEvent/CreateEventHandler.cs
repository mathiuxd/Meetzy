using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Events.Commands.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, CreateEventResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateEventResponse> Handle(CreateEventRequest request)
        {
            var @event = new Event(
                request.Title,
                request.Location,
                request.City,
                request.DateTime,
                request.CreatorId,
                request.Description,
                request.MaxAttendees,
                request.CommunityId
            );

            await _unitOfWork.Events.AddAsync(@event);
            await _unitOfWork.SaveChangesAsync();

            return new CreateEventResponse(
                @event.EventId,
                @event.Title,
                @event.Location,
                @event.City,
                @event.DateTime,
                @event.CreatorId,
                @event.CommunityId,
                @event.CreatedAt
            );
        }
    }
}
