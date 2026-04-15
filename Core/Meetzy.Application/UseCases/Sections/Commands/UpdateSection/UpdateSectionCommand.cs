using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
    }
}
