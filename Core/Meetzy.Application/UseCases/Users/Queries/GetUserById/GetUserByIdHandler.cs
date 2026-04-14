using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException($"User not found: {request.UserId}");
            }

            return new GetUserByIdResponse(user.UserId, user.Name, user.Email, user.RoleId, user.CreatedAt);
        }
    }
}
