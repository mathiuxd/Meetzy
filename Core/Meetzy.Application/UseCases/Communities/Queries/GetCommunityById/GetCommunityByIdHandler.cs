using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Queries.GetCommunityById
{
    public class GetCommunityByIdHandler : IRequestHandler<GetCommunityByIdRequest, GetCommunityByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommunityByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCommunityByIdResponse> Handle(GetCommunityByIdRequest request)
        {
            var community = await _unitOfWork.Communities.GetByIdAsync(request.CommunityId);
            if (community == null)
                throw new Exception("Community not found.");

            return new GetCommunityByIdResponse(
                community.CommunityId,
                community.Name,
                community.Description,
                community.CreatedAt
            );
        }
    }
}
