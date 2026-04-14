using System;
using System.Collections.Generic;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Queries.GetAllUsers
{
    public record GetAllUsersRequest() : IRequest<IEnumerable<GetAllUsersResponse>>;

    public record GetAllUsersResponse(
        Guid UserId,
        string Name,
        string Email,
        Guid RoleId
    );
}
