using System;

namespace Meetzy.Domain;

public class Comment
{
    public Guid ContentId { get; private set; }
    public Guid EventId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Event Event { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public string Content { get; private set; } = string.Empty; 

    private Comment() { }

    public Comment(Guid eventId, Guid userId, string content)
    {
        ContentId = Guid.NewGuid();
        EventId = eventId;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
}
