using Meetzy.Application.Contracts.Persistence;
using Meetzy.Domain;

namespace Meetzy.Application.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}