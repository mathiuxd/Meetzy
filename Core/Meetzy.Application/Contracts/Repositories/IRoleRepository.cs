using Meetzy.Application.Contracts.Persistence;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByNameAsync(string name);
    }
}
