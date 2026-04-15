using Meetzy.Domain.Exceptions;

namespace Meetzy.Domain;

public class Community
{
    public Guid CommunityId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public CommunityType Type { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public User Creator { get; private set; } = null!;
    public ICollection<CommunityMember> Members { get; private set; } = [];

    private Community() { }

    public Community(string name, CommunityType type, Guid createdBy, string? description = null)
    {
        ValidateName(name);
        CommunityId = Guid.NewGuid();
        Name = name;
        Type = type;
        CreatedBy = createdBy;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BussinessRuleExceptions("El nombre de la comunidad no puede estar vacío.");
        if (name.Length > 150)
            throw new BussinessRuleExceptions("El nombre no puede superar los 150 caracteres.");
    }
}
