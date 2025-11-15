using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.DomainEvents;

namespace Hababk.Modules.Identities.Domain.Entities;

public class Role :Entity,IAggregateRoot
{
    
    private Role(Guid id,string roleName) : base(id)
    {
        RoleName = roleName ?? throw new ArgumentNullException(nameof(roleName));
        AddDomainEvent(new CreatedRoleDomainEvent(this));
    }

    public string RoleName { get; private set; }


    public static Role Create(string roleName) 
        => new(Guid.NewGuid(),roleName);

   
}