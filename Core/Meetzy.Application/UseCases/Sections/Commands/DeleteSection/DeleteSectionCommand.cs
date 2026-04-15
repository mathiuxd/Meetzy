using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
