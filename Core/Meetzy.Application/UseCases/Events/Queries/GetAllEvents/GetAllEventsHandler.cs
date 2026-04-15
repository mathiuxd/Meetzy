using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Queries.GetAllEvents
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, IEnumerable<GetAllEventsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEventsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllEventsResponse>> Handle(GetAllEventsRequest request)
        {
            var events = await _unitOfWork.Events.GetAllAsync();

            return events.Select(@event => new GetAllEventsResponse(
                @event.EventId,
                @event.Title,
                @event.City,
                @event.EventDateTime,
                @event.CreatorId
            ));
        }
    }
}
