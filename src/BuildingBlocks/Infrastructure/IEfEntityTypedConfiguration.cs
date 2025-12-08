using Microsoft.EntityFrameworkCore;

namespace Hababk.BuildingBlocks.Infrastructure;

public interface IEfEntityTypedConfiguration<T> :IEntityTypeConfiguration<T>  where T : class
{
    
}