using Meetzy.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetzy.Domain.Entities.Abstractions
{
    public static class DomainValidations
    {
        public static void ApplyBussinessRuleForName(string name)
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
