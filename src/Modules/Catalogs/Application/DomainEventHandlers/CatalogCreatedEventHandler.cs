using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Catalogs.Domain.DomainEvents;

namespace Hababk.Modules.Catalogs.Application.DomainEventHandlers;

public class CatalogCreatedEventHandler :IDomainEventHandler<CatalogCreatedEvent>
{
    public Task Handle(CatalogCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}