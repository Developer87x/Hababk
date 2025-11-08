using Hababk.BuildingBlocks.Domain;
using MediatR;

namespace Hababk.BuildingBlocks.Application;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}