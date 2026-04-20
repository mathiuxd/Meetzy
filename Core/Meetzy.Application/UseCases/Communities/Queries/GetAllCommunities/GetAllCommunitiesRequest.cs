using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Queries.GetAllCommunities
{
    public record GetAllCommunitiesRequest() : IRequest<IEnumerable<GetAllCommunitiesResponse>>;

    public record GetAllCommunitiesResponse(
        Guid CommunityId,
        string Name,
        string? Description,
        DateTime CreatedAt
    );
}
