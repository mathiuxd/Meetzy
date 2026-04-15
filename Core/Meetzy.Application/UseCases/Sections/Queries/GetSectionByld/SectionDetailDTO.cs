namespace Meetzy.Application.UseCases.Sections.Queries.GetSectionByld
{
    public class SectionDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
