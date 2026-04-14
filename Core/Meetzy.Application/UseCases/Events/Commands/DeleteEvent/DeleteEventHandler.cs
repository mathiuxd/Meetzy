using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Commands.DeleteEvent
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, DeleteEventResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteEventResponse> Handle(DeleteEventRequest request)
        {
            var @event = await _unitOfWork.Events.GetByIdAsync(request.EventId);
            if (@event is null)
            {
                throw new InvalidOperationException($"Event not found: {request.EventId}");
            }

            _unitOfWork.Events.Delete(@event);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteEventResponse(@event.EventId);
        }
    }
}
