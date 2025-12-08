
using Hababk.Modules.Identities.Application.Models;

namespace Hababk.Modules.Identities.Application.Queries;

public interface IRoleQueries
{
    Task<bool> RoleExistsAsync(string roleName);
    Task<RoleDto?> GetRoleByNameAsync(string roleName); 
}