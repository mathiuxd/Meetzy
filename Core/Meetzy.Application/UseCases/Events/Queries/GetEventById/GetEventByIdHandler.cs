using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Queries.GetEventById
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdRequest, GetEventByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetEventByIdResponse> Handle(GetEventByIdRequest request)
        {
            var @event = await _unitOfWork.Events.GetByIdAsync(request.EventId);
            if (@event is null)
            {
                throw new InvalidOperationException($"Event not found: {request.EventId}");
            }

            return new GetEventByIdResponse(
                @event.EventId,
                @event.Title,
                @event.Description,
                @event.Location,
                @event.City,
                @event.EventDateTime,
                @event.MaxAttendees,
                @event.CreatorId,
                @event.CommunityId,
                @event.CreatedAt
            );
        }
    }
}
