using Meetzy.Application.Contracts.Repositories;
using Meetzy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meetzy.Persistence.Repositories
{
    public class EfCoreEventRepository : IEventRepository
    {
        private readonly DataContext _dbContext;

        public EfCoreEventRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Event entity)
        {
            await _dbContext.Events.AddAsync(entity);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _dbContext.Events.Include(e => e.Creator).ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Events.Include(e => e.Creator).FirstOrDefaultAsync(e => e.EventId == id);
        }

        public void Update(Event entity)
        {
            _dbContext.Events.Update(entity);
        }

        public void Delete(Event entity)
        {
            _dbContext.Events.Remove(entity);
        }

        public async Task<IEnumerable<Event>> GetByCityAsync(string city)
        {
            return await _dbContext.Events.Where(e => e.City == city).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetByCreatorAsync(Guid creatorId)
        {
            return await _dbContext.Events.Where(e => e.CreatorId == creatorId).ToListAsync();
        }
    }
}