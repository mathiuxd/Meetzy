using Meetzy.Aplication.Contracts.Persistence;
using System.Collections.Generic;
using System.Text;
using System;

namespace Meetzy.Persistence.UnitOfWorks
{
	public class EfCoreUnitOfWork : IUnitOfWork
	{
		private readonly MeetzyDbContext _dbContext;

		public EfCoreUnitOfWork(MeetzyDbContext dbContext)
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

	}
}