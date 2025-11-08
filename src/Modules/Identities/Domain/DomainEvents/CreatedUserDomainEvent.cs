using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Domain.DomainEvents;

public class CreatedUserDomainEvent :IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public User? User { get;  }

    public CreatedUserDomainEvent(User user)
    {
        Id = user.Id ;
        CreatedAt = DateTime.UtcNow;
        User = user;
    }
}