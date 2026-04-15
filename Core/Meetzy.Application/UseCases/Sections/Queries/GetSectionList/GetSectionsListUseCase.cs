using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionList
{
    public class GetSectionsListUseCase : IRequestHandler<GetSectionsListQuery, IEnumerable<SectionListItemDTO>>
    {
        private readonly ISectionsRepository _sectionsRepository;

        public GetSectionsListUseCase(ISectionsRepository sectionsRepository)
        {
            _sectionsRepository = sectionsRepository;
        }

        public async Task<IEnumerable<SectionListItemDTO>> Handle(GetSectionsListQuery request)
        {
            IEnumerable<Section> sections = await _sectionsRepository.GetAllAsync();

            List<SectionListItemDTO> sectionsDTO = sections.Select(s => s.ToDTO())
                                                           .ToList();

            return sectionsDTO;
        }
    }
}
