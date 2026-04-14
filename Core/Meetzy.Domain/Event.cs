using System;

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
}
