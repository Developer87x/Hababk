using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Identities.Domain.Entities;

public interface IUserRepository :IRepository<User>
{
    Task<User> AddAsync(User user);
    Task<User?> GetByUserNameAsync(string username);
    
}
