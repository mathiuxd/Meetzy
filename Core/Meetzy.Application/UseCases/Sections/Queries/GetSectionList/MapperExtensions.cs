using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionList
{
    internal static class MapperExtensions
    {
        public static SectionListItemDTO ToDTO(this Section section)
        {
            return new SectionListItemDTO
            {
                Id = section.Id,
                Name = section.Name,
                IsActive = section.IsActive
            };
        }
    }
}
