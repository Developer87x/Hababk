using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Application.Models;

namespace Hababk.Modules.Identities.Application.Queries;

public interface IUserQueries :IQuery<UserDto>
{
    Task<UserDto?> GetByUserNameAsync(string userName);
}
