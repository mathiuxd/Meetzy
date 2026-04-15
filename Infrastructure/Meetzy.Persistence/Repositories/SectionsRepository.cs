using Meetzy.Application.Contracts.Repositories;
using Meetzy.Domain;
using Meetzy.Persistence;

namespace Meetzy.Persistence.Repositories
{
	public class SectionsRepository : Repository<Section>, ISectionsRepository
	{
		public SectionsRepository(DataContext dbContext) : base(dbContext)
		{
		}
	}
}