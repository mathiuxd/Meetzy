using Meetzy.Aplication.Contracts.Repositories;
using Meetzy.Domain.Entities.Sections;

namespace Meetzy.Persistence.Repositories
{
	public class SectionsRepository : Repository<Section>, ISectionsRepository
	{
		public SectionsRepository(MeetzyDbContext dbContext) : base(dbContext)
		{
		}
	}
}