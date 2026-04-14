using System.Collections.Generic;
using System.Threading.Tasks;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories
{
    public interface ICommunityRepository : IRepository<Community>
    {
        Task<IEnumerable<Community>> GetByTypeAsync(CommunityType type);
    }
}
