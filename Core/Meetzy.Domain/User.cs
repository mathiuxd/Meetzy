using Meetzy.Domain.Exceptions;

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

    private User() { }

    public User(string name, string email, string password, Guid roleId)
    {
        ValidateName(name);
        ValidateEmail(email);

        UserId = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void UpdateEmail(string email)
    {
        ValidateEmail(email);
        Email = email;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BussinessRuleExceptions("El nombre no puede estar vacío.");
        if (name.Length > 100)
            throw new BussinessRuleExceptions("El nombre no puede superar los 100 caracteres.");
    }

    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new BussinessRuleExceptions("El email no puede estar vacío.");
        if (!email.Contains('@'))
            throw new BussinessRuleExceptions("El email no tiene un formato válido.");
        if (email.Length > 200)
            throw new BussinessRuleExceptions("El email no puede superar los 200 caracteres.");
    }
}
