using Meetzy.Domain.Exceptions;

namespace Meetzy.Domain.Entities.Role
{
    public sealed class Role
    {
        public Guid RoleId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Role(string name, string description)
        {
            ApplyBussinessRuleForName(name);

            RoleId = Guid.CreateVersion7();
            Name = name;
            Description = description;
        }

        private static void ApplyBussinessRuleForName(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BussinessRuleExceptions($"El {nameof(name)} es requerido.");

            if (name.Length < 4)
                throw new BussinessRuleExceptions($"El {nameof(name)} debe ser mayor a 4 letras");

            if (name.Length > 32)
                throw new BussinessRuleExceptions($"El {nameof(name)} debe ser menor a 32 letras");
        }
    }
}