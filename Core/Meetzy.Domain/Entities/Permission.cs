namespace Meetzy.Domain;

public class Permission
{
    public Guid PermissionId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    private Permission() { }

    public Permission(string name, string? description)
    {
        PermissionId = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}
