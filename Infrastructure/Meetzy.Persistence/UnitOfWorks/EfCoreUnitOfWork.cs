using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Persistence;

namespace Meetzy.Persistence.UnitOfWorks
{
	public class EfCoreUnitOfWork : IUnitOfWork
	{
		private readonly DataContext _dbContext;

		public IUserRepository Users => throw new NotImplementedException();

		public IEventRepository Events => throw new NotImplementedException();

		public ICommunityRepository Communities => throw new NotImplementedException();

		public IFriendshipRepository Friendships => throw new NotImplementedException();

		public ICommentRepository Comments => throw new NotImplementedException();

		public ISectionsRepository Sections => throw new NotImplementedException();

		public EfCoreUnitOfWork(DataContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public async Task CommitAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public Task RollbackAsync() 
		{
			return Task.CompletedTask;
		}

		public Task<int> SaveChangesAsync()
		{
			return _dbContext.SaveChangesAsync();
		}
	}
}