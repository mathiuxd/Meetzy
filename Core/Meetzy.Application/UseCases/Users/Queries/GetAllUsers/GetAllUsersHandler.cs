using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<GetAllUsersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllUsersResponse>> Handle(GetAllUsersRequest request)
        {
            var users = await _unitOfWork.Users.GetAllAsync();

            return users.Select(user => new GetAllUsersResponse(
                user.UserId,
                user.Name,
                user.Email,
                user.RoleId
            ));
        }
    }
}
