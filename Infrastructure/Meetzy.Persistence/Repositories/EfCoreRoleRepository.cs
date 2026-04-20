using Meetzy.Application.Contracts.Repositories;
using Meetzy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meetzy.Persistence.Repositories
{
    public class EfCoreRoleRepository : IRoleRepository
    {
        private readonly DataContext _dbContext;

        public EfCoreRoleRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public void Update(Role role)
        {
            _dbContext.Roles.Update(role);
        }

        public void Delete(Role role)
        {
            _dbContext.Roles.Remove(role);
        }
    }
}
