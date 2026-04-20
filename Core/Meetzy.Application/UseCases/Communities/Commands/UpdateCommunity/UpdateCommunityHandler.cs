using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Commands.UpdateCommunity
{
    public class UpdateCommunityHandler : IRequestHandler<UpdateCommunityRequest, UpdateCommunityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCommunityResponse> Handle(UpdateCommunityRequest request)
        {
            var community = await _unitOfWork.Communities.GetByIdAsync(request.CommunityId);
            if (community == null)
                throw new Exception("Community not found.");

            community.UpdateDetails(request.Name, request.Description);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateCommunityResponse(
                community.CommunityId,
                community.Name,
                community.Description
            );
        }
    }
}