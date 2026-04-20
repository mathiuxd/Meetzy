using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Queries.GetAllCommunities
{
    public class GetAllCommunitiesHandler : IRequestHandler<GetAllCommunitiesRequest, IEnumerable<GetAllCommunitiesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCommunitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllCommunitiesResponse>> Handle(GetAllCommunitiesRequest request)
        {
            var communities = await _unitOfWork.Communities.GetAllAsync();
            return communities.Select(c => new GetAllCommunitiesResponse(
                c.CommunityId,
                c.Name,
                c.Description,
                c.CreatedAt
            ));
        }
    }
}
