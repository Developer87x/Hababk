using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Infrastructure.Repositories;

public class RoleUserRepository(IdentitiesDbContext dbContext) : IRoleUserRepository
{

    private readonly IdentitiesDbContext _dbContext = dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public async Task<UserRole> AddAsync(UserRole userRole)
    {
        var entityEntry = await _dbContext.UserRoles.AddAsync(userRole);
        return entityEntry.Entity;
    }
}