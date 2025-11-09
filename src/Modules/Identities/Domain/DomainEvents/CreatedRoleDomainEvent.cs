using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Domain.DomainEvents;

public class CreatedRoleDomainEvent(Role role) : IDomainEvent
{
    public Guid Id { get; } = role.Id;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public Role? Role { get; } = role;
}