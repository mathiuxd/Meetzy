using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Commands.DeleteCommunity
{
    public record DeleteCommunityRequest(Guid CommunityId) : IRequest<DeleteCommunityResponse>;
    public record DeleteCommunityResponse(Guid CommunityId);
}