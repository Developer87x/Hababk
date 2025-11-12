using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Stores.Domain.Entities;

namespace Hababk.Modules.Stores.Application.Commands;

public class CreateStoreCommandHandler(IStoreRepository storeRepository) : ICommandHandler<CreateStoreCommand,bool>
{
    private readonly IStoreRepository _storeRepository = storeRepository;

    public async Task<bool> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
      
        var store = Store.Create(request.StoreName!,null,request.UserId!,request.ContactEmail!,request.ContactNumber!);
         await _storeRepository.AddAsync(store);
         var result = await _storeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
         return result;
    }
} 