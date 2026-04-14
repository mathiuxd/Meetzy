using System;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Domain;

public class Event
{
    public Guid EventId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public string Location { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public DateTime DateTime { get; private set; }   
    public int? MaxAttendees { get; private set; }
    public Guid CreatorId { get; private set; }
    public Guid? CommunityId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public User Creator { get; private set; } = null!;
    public Community? Community { get; private set; }
    public ICollection<EventAttendee> Attendees { get; private set; } = [];
    public ICollection<Comment> Comments { get; private set; } = [];

    public Event(string title, string location, string city, DateTime dateTime, Guid creatorId, string? description = null, int? maxAttendees = null, Guid? communityId = null)
    {   
        ValidateTitle(title);
        ValidateDateTime(dateTime);
        
        EventId = Guid.NewGuid();
        Title = title;
        Location = location;
        City = city;
        DateTime = dateTime;
        CreatorId = creatorId;
        Description = description;
        MaxAttendees = maxAttendees;
        CommunityId = communityId;
        CreatedAt = System.DateTime.UtcNow;
    }

    public void UpdateTitle(string title)
    {
        ValidateTitle(title);
        Title = title;
    }

    public void UpdateDescription(string? description) => Description = description;

    public void UpdateDateTime(System.DateTime dateTime)
    {
        ValidateDateTime(dateTime);
        DateTime = dateTime;
    }

    public void UpdateMaxAttendees(int? max)
    {
        if (max is < 1)
            throw new BussinessRuleExceptions("El máximo de asistentes debe ser mayor a 0.");
        MaxAttendees = max;
    }

    private static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new BussinessRuleExceptions("El título no puede estar vacío.");
        if (title.Length > 200)
            throw new BussinessRuleExceptions("El título no puede superar los 200 caracteres.");
    }

    private static void ValidateDateTime(System.DateTime dateTime)
    {
        if (dateTime <= System.DateTime.UtcNow)
            throw new BussinessRuleExceptions("La fecha del evento debe ser en el futuro.");
    }
}
