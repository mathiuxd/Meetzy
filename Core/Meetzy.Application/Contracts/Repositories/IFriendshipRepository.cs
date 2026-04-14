using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories
{
    public interface IFriendshipRepository : IRepository<Friendship>
    {
        Task<IEnumerable<Friendship>> GetByUserAsync(Guid userId);
    }
}
