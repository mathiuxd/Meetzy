using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Communities.Commands.CreateCommunity
{
    public class CreateCommunityHandler : IRequestHandler<CreateCommunityRequest, CreateCommunityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCommunityResponse> Handle(CreateCommunityRequest request)
        {
            var community = new Community(
                request.Name,
                (CommunityType)request.Type,
                request.CreatedBy,
                request.Description
            );

            await _unitOfWork.Communities.AddAsync(community);
            await _unitOfWork.SaveChangesAsync();

            return new CreateCommunityResponse(
                community.CommunityId,
                community.Name,
                community.Description,
                community.CreatedAt
            );
        }
    }
}
