using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByEventAsync(Guid eventId);
    }
}
