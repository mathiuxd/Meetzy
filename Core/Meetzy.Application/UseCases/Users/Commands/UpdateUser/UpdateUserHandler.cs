using System;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException($"User not found: {request.UserId}");
            }

            user.UpdateName(request.Name);
            user.UpdateEmail(request.Email);

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateUserResponse(user.UserId, user.Name, user.Email, user.RoleId);
        }
    }
}
