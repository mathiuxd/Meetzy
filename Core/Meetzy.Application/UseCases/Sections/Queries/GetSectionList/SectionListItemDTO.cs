namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionList
{
    public class SectionListItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
