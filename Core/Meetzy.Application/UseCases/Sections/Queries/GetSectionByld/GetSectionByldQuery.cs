using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionByld
{
    public class GetSectionByIdQuery : IRequest<SectionDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
