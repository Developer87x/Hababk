using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Identities.Domain.Entities;

public class Role :Entity
{
    
    private Role(Guid id,string roleName) : base(id)
    {
        RoleName = roleName;
    }

    public string RoleName { get; private set; }

   
}