
using Meetzy.Domain.Entities.Abstractions;

namespace Meetzy.Domain.Entities.Permission
{
    public class Permission
    {
        public Guid PermissionId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Permission(string name, string? description)
        {
            DomainValidations.ApplyBussinessRuleForName(name);

            PermissionId = Guid.CreateVersion7();
            Name = name;
            Description = description;
        }
    }
}
