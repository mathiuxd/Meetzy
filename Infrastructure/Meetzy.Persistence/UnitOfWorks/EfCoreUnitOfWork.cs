using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Persistence.Repositories;

namespace Meetzy.Persistence.UnitOfWorks
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        public IUserRepository Users { get; }
        public IEventRepository Events { get; }
        public ICommunityRepository Communities => throw new NotImplementedException();
        public IFriendshipRepository Friendships => throw new NotImplementedException();
        public ICommentRepository Comments => throw new NotImplementedException();
        public ISectionsRepository Sections => throw new NotImplementedException();
        public IRoleRepository Roles { get; }

        public EfCoreUnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Users = new EfCoreUserRepository(_dbContext);
            Roles = new EfCoreRoleRepository(_dbContext);
            Events = new EfCoreEventRepository(_dbContext);
        }

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();
        public Task RollbackAsync() => Task.CompletedTask;
        public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}