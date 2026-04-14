using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException($"User not found: {request.UserId}");
            }

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteUserResponse(user.UserId);
        }
    }
}
