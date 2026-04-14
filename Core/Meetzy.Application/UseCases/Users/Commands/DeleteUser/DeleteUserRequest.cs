using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.DeleteUser
{
    public record DeleteUserRequest(Guid UserId) : IRequest<DeleteUserResponse>;

    public record DeleteUserResponse(Guid UserId);
}
