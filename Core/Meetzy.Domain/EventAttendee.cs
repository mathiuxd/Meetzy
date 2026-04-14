using System;

namespace Meetzy.Domain;

public class EventAttendee
{
    public Guid Id { get; private set; }
    public Guid EventId { get; private set; }
    public Guid UserId { get; private set; }
    public AttendanceStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Event Event { get; private set; } = null!;
    public User User { get; private set; } = null!;

    private EventAttendee() { }

    public EventAttendee(Guid eventId, Guid userId, AttendanceStatus status)
    {
        Id = Guid.NewGuid();
        EventId = eventId;
        UserId = userId;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }
}
