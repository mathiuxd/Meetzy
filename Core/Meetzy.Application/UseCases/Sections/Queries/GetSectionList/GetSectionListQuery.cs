using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionList
{
    public class GetSectionsListQuery : IRequest<IEnumerable<SectionListItemDTO>>
    {
    }
}
