using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.LoginUser;

public class LoginUserRequest : IRequest<LoginUserResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

