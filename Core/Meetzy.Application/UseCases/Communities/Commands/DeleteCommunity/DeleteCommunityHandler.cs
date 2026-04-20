using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Communities.Commands.DeleteCommunity
{
    public class DeleteCommunityHandler : IRequestHandler<DeleteCommunityRequest, DeleteCommunityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCommunityResponse> Handle(DeleteCommunityRequest request)
        {
            var community = await _unitOfWork.Communities.GetByIdAsync(request.CommunityId);
            if (community == null)
                throw new Exception("Community not found.");

            _unitOfWork.Communities.Delete(community);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteCommunityResponse(request.CommunityId);
        }
    }
}