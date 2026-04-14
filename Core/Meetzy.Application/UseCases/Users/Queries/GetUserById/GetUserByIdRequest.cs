using System;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Queries.GetUserById
{
    public record GetUserByIdRequest(Guid UserId) : IRequest<GetUserByIdResponse>;

    public record GetUserByIdResponse(
        Guid UserId,
        string Name,
        string Email,
        Guid RoleId,
        DateTime CreatedAt
    );
}
