using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure.Repositories;

public class RoleRepository(IdentitiesDbContext dbContext) : IRoleRepository
{
    private readonly IdentitiesDbContext _dbContext = dbContext;
    public IUnitOfWork UnitOfWork => _dbContext;
    public async Task<Role> AddAsync(Role role)
    {
        var entityEntry = await  _dbContext.Roles.AddAsync(role);
        return entityEntry.Entity;
    }
    public async Task<Role?> GetByIdAsync(Guid roleId)
    {
        var entityEntry = await _dbContext.Roles.Where(s=>s.Id == roleId).FirstOrDefaultAsync();
        return entityEntry;
    }
}
