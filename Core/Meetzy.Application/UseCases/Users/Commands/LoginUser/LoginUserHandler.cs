using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Users.Commands.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IUserRepository _userRepository;

    public LoginUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || user.Password != request.Password)
            throw new Exception("Credenciales inválidas.");

        return new LoginUserResponse { UserId = user.UserId, Name = user.Name, Role = user.Role.Name };
    }
}

public class LoginUserResponse
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}