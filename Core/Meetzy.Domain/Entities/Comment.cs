using Meetzy.Domain.Exceptions;

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
        ValidateContent(content);

        ContentId = Guid.NewGuid();
        EventId = eventId;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateContent(string content)
    {
        ValidateContent(content);
        Content = content;
    }

    private static void ValidateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new BussinessRuleExceptions("El comentario no puede estar vacío.");
        if (content.Length > 500)
            throw new BussinessRuleExceptions("El comentario no puede superar los 500 caracteres.");
    }
}
