using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Events.Queries.GetEventById
{
    public record GetEventByIdRequest(Guid EventId) : IRequest<GetEventByIdResponse>;

    public record GetEventByIdResponse(
        Guid EventId,
        string Title,
        string? Description,
        string Location,
        string City,
        DateTime DateTime,
        int? MaxAttendees,
        Guid CreatorId,
        Guid? CommunityId,
        DateTime CreatedAt
    );
}
