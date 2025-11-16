using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Identities.Domain.Entities;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> AddAsync(Role role);
}