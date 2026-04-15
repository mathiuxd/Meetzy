using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Commands.CreateSection
{
    public class CreateSectionCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}