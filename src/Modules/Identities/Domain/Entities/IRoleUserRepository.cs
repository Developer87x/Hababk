namespace Hababk.Modules.Identities.Domain.Entities;

public interface IRoleUserRepository 
{
    Task<UserRole> AddAsync(UserRole userRole);    
    Task<IList<UserRole>> GetRolesIdAsync(Guid? userId);
}