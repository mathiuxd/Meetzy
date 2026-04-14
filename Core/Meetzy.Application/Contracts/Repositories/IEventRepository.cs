using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetByCityAsync(string city);
        Task<IEnumerable<Event>> GetByCreatorAsync(Guid creatorId);
    }
}
