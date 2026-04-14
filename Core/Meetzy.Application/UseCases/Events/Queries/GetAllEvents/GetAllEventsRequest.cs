using System;
using System.Collections.Generic;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Queries.GetAllEvents
{
    public record GetAllEventsRequest() : IRequest<IEnumerable<GetAllEventsResponse>>;

    public record GetAllEventsResponse(
        Guid EventId,
        string Title,
        string City,
        DateTime DateTime,
        Guid CreatorId
    );
}
