using Hababk.BuildingBlocks.Application;

namespace Hababk.Modules.Catalogs.Application.Commands;

public class CreateCatalogCommandHandler :ICommandHandler<CreateCatalogCommand,bool>
{
    public Task<bool> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}