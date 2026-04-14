using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request)
        {
            var user = new User(request.Name, request.Email, request.Password, request.RoleId);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new CreateUserResponse(user.UserId, user.Name, user.Email, user.RoleId, user.CreatedAt);
        }
    }
}
