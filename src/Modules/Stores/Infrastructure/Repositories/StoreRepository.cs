using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Stores.Infrastructure.Repositories;

public class StoreRepository(StoreDbContext context) : IStoreRepository
{
    private readonly StoreDbContext _context = context;

    public IUnitOfWork UnitOfWork => _context;
    public async Task<Store?> GetByIdAsync(Guid id) =>await _context.Stores.Where(s=>s.Id==id).FirstOrDefaultAsync();
    public async Task<Store> AddAsync(Store store)
    {
            var result=await _context.Stores.AddAsync(store);
            return result.Entity;
    }
}