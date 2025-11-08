using MediatR;

namespace Hababk.BuildingBlocks.Domain;

public interface IDomainEvent :INotification
{
    Guid Id { get; }
    DateTime CreatedAt { get; }
}