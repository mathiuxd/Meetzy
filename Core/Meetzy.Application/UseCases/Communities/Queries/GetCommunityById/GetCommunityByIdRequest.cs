using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Queries.GetCommunityById
{
    public record GetCommunityByIdRequest(Guid CommunityId) : IRequest<GetCommunityByIdResponse>;

    public record GetCommunityByIdResponse(
        Guid CommunityId,
        string Name,
        string? Description,
        DateTime CreatedAt
    );
}