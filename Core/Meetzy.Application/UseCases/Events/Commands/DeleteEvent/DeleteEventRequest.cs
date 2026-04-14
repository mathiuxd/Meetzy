using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Commands.DeleteEvent
{
    public record DeleteEventRequest(Guid EventId) : IRequest<DeleteEventResponse>;

    public record DeleteEventResponse(Guid EventId);
}
