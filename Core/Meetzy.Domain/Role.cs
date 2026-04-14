using System;

namespace Meetzy.Domain;

public class Role
{
    public Guid RoleId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public ICollection<RolePermission> Permissions { get; private set; } = [];

    private Role() { }//Esto es para EF

     public Role(string name, string? description)
    {
        RoleId = Guid.NewGuid();
        Name = name;
        Description = description;
    }


}
