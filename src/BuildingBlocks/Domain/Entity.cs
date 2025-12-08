namespace Hababk.BuildingBlocks.Domain;

public abstract class Entity(Guid id)
{
    public Guid Id { get; protected set; } = id;
    private IList<IDomainEvent>? _domainEvents;

    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= [];
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();
}