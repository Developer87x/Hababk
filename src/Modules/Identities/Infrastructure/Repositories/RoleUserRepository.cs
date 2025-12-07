using System.Collections.Generic;
using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IList<UserRole>> GetRolesIdAsync(Guid? userId)
    {
        var userRoles =   _dbContext.UserRoles.Where(ur => ur.UserId == userId);
        return   await userRoles.ToListAsync();
    }
}