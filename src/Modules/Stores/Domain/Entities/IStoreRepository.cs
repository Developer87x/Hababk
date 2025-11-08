using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Stores.Domain.Entities;

public interface IStoreRepository :IRepository<Store>{
    Task<Store?> GetByIdAsync(Guid id);
    Task<Store> AddAsync(Store store);
}