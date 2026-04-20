using Microsoft.EntityFrameworkCore;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Domain;

namespace Meetzy.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
