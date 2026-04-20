using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Commands.CreateCommunity
{
    public record CreateCommunityRequest(
        string Name,
        string? Description,
        int Type,
        Guid CreatedBy
    ) : IRequest<CreateCommunityResponse>;

    public record CreateCommunityResponse(
        Guid CommunityId,
        string Name,
        string? Description,
        DateTime CreatedAt
    );
}