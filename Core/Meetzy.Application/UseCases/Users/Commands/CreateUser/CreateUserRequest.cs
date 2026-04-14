using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.CreateUser
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Password,
        Guid RoleId
    ) : IRequest<CreateUserResponse>;

    public record CreateUserResponse(
        Guid UserId,
        string Name,
        string Email,
        Guid RoleId,
        DateTime CreatedAt
    );
}
