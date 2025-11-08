using MediatR;

namespace Hababk.BuildingBlocks.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    private IList<IDomainEvent>? _domainEvents;

    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= [];
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();
    protected Entity(Guid id) => Id = id;
}