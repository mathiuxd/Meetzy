using Meetzy.Domain.Exceptions;

namespace Meetzy.Domain;

public class Friendship
{
    public Guid Id { get; private set; }
    public Guid UserSendId { get; private set; }
    public Guid UserReceivesId { get; private set; }
    public FriendshipStatus Status { get; private set; }
    public User UserSend { get; private set; } = null!;
    public User UserReceives { get; private set; } = null!;

    private Friendship() { }

    public Friendship(Guid userSendId, Guid userReceivesId)
    {
        Id = Guid.NewGuid();
        UserSendId = userSendId;
        UserReceivesId = userReceivesId;
        Status = FriendshipStatus.Pending;
    }

    public void Accept()
    {
        if (Status != FriendshipStatus.Pending)
            throw new BussinessRuleExceptions("Solo se pueden aceptar solicitudes pendientes.");
        Status = FriendshipStatus.Accepted;
    }

    public void Reject()
    {
        if (Status != FriendshipStatus.Pending)
            throw new BussinessRuleExceptions("Solo se pueden rechazar solicitudes pendientes.");
        Status = FriendshipStatus.Rejected;
    }
}
