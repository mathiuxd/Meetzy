using Meetzy.Domain.Exceptions;

namespace Meetzy.Domain;

public class Section
{
    public Guid SectionId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Section() { }

    public Section(string name, Guid createdBy, string? description = null)
    {
        ValidateName(name);
        SectionId = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
        IsActive = false;
    }

    public void Activate()
    {
        if (IsActive)
            throw new BussinessRuleExceptions("La sección ya está activa.");
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new BussinessRuleExceptions("La sección ya está inactiva.");
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id => SectionId;

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BussinessRuleExceptions("El nombre de la sección no puede estar vacío.");
        if (name.Length > 150)
            throw new BussinessRuleExceptions("El nombre no puede superar los 150 caracteres.");
    }
}
