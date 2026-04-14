using System;

namespace Meetzy.Domain;

public class User
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string? Phone { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public string? ProfilePhoto { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; } = null!;


    private User() { } // Esto es para EF

    public User(string name, string email, string password, Guid roleId)
    {
        UserId = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
    }
}
