using Meetzy.Domain.Entities.Abstractions;
using Meetzy.Domain.Exceptions;
using System.Xml.Linq;

namespace Meetzy.Domain.Entities.Role
{
    public sealed class Roles
    {
        public Guid RoleId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Roles(string name, string? description)
        {
            DomainValidations.ApplyBussinessRuleForName(name);

            RoleId = Guid.CreateVersion7();
            Name = name;
            Description = description;
        }

        
    }
}