using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Commands.UpdateEvent
{
    public record UpdateEventRequest(
        Guid EventId,
        string Title,
        string? Description,
        DateTime DateTime,
        int? MaxAttendees
    ) : IRequest<UpdateEventResponse>;

    public record UpdateEventResponse(
        Guid EventId,
        string Title,
        string? Description,
        DateTime DateTime,
        int? MaxAttendees
    );
}
