using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.UpdateUser
{
    public record UpdateUserRequest(
        Guid UserId,
        string Name,
        string Email
    ) : IRequest<UpdateUserResponse>;

    public record UpdateUserResponse(
        Guid UserId,
        string Name,
        string Email,
        Guid RoleId
    );
}
