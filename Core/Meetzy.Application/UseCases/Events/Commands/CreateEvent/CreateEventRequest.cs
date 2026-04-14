using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Commands.CreateEvent
{
    public record CreateEventRequest(
        string Title,
        string Location,
        string City,
        DateTime DateTime,
        Guid CreatorId,
        string? Description,
        int? MaxAttendees,
        Guid? CommunityId
    ) : IRequest<CreateEventResponse>;

    public record CreateEventResponse(
        Guid EventId,
        string Title,
        string Location,
        string City,
        DateTime DateTime,
        Guid CreatorId,
        Guid? CommunityId,
        DateTime CreatedAt
    );
}
