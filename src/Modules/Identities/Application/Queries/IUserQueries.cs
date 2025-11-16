using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Application.Dtos;

namespace Hababk.Modules.Identities.Application.Queries;

public interface IUserQueries :IQuery<UserDto>
{
    Task<UserDto?> GetByUserNameAsync(string userName);
}
