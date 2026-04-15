using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionByld
{
    public class GetSectionByIdUseCase : IRequestHandler<GetSectionByIdQuery, SectionDetailDTO>
    {
        private readonly ISectionsRepository _sectionsRepository;

        public GetSectionByIdUseCase(ISectionsRepository sectionsRepository)
        {
            _sectionsRepository = sectionsRepository;
        }

        public async Task<SectionDetailDTO> Handle(GetSectionByIdQuery request)
        {
            Section? section = await _sectionsRepository.GetByIdAsync(request.Id);

            if (section == null)
            {
                throw new BussinessRuleExceptions("La sección no existe");
            }

            return new SectionDetailDTO
            {
                Id = section.Id,
                Name = section.Name,
                IsActive = section.IsActive
            };
        }
    }
}
