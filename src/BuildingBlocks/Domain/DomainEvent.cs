namespace Hababk.BuildingBlocks.Domain;

public class DomainEvent : IDomainEvent
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
}