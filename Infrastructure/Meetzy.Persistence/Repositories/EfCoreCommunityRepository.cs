using Meetzy.Application.Contracts.Repositories;
using Meetzy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meetzy.Persistence.Repositories
{
    public class EfCoreCommunityRepository : ICommunityRepository
    {
        private readonly DataContext _dbContext;

        public EfCoreCommunityRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Community entity)
        {
            await _dbContext.Communities.AddAsync(entity);
        }

        public async Task<IEnumerable<Community>> GetAllAsync()
        {
            return await _dbContext.Communities.ToListAsync();
        }

        public async Task<Community?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Communities
                .FirstOrDefaultAsync(c => c.CommunityId == id);
        }

        public void Update(Community entity)
        {
            _dbContext.Communities.Update(entity);
        }

        public void Delete(Community entity)
        {
            _dbContext.Communities.Remove(entity);
        }

        public async Task<IEnumerable<Community>> GetByTypeAsync(CommunityType type)
        {
            return await _dbContext.Communities
                .Where(c => c.Type == type)
                .ToListAsync();
        }
    }
}