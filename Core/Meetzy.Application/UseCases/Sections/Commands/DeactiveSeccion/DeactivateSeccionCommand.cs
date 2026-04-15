using Meetzy.Application.Utilities.Mediator;
using System;

namespace Meetzy.Application.UseCases.Sections.Commands.DeactiveSeccion
{
    public class DeactivateSeccionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
