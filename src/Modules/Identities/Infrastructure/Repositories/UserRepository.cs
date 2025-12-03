using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure.Repositories;

public class UserRepository(IdentitiesDbContext dbContext) : IUserRepository
{

    private readonly IdentitiesDbContext _dbContext = dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public async Task<User> AddAsync(User user)
    {
        var entityEntry = await _dbContext.Users.AddAsync(user);
        return entityEntry.Entity;
    }

    public async Task<User?> GetByUserNameAsync(string username)
    {
       var entityEntry = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username);
       return entityEntry;
    }
}
