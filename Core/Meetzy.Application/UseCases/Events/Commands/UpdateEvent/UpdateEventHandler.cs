using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Commands.UpdateEvent
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, UpdateEventResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateEventResponse> Handle(UpdateEventRequest request)
        {
            var @event = await _unitOfWork.Events.GetByIdAsync(request.EventId);
            if (@event is null)
            {
                throw new InvalidOperationException($"Event not found: {request.EventId}");
            }

            @event.UpdateTitle(request.Title);
            @event.UpdateDescription(request.Description);
            @event.UpdateDateTime(request.DateTime);
            @event.UpdateMaxAttendees(request.MaxAttendees);

            _unitOfWork.Events.Update(@event);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateEventResponse(
                @event.EventId,
                @event.Title,
                @event.Description,
                @event.DateTime,
                @event.MaxAttendees
            );
        }
    }
}
