using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Commands.UpdateCommunity
{
    public record UpdateCommunityRequest(
        Guid CommunityId,
        string Name,
        string? Description
    ) : IRequest<UpdateCommunityResponse>;

    public record UpdateCommunityResponse(
        Guid CommunityId,
        string Name,
        string? Description
    );
}