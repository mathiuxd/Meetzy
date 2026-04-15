using System.Threading.Tasks;
using Meetzy.Application.Contracts.Repositories;

namespace Meetzy.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IEventRepository Events { get; }
        ICommunityRepository Communities { get; }
        IFriendshipRepository Friendships { get; }
        ICommentRepository Comments { get; }
        ISectionsRepository Sections { get; }

        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}
