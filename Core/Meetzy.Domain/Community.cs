using System;

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
        CommunityId = Guid.NewGuid();
        Name = name;
        Type = type;
        CreatedBy = createdBy;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}
