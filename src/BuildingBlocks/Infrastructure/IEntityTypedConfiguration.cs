using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hababk.BuildingBlocks.Infrastructure;

public interface IEntityTypedConfiguration<T> :IEntityTypeConfiguration<T>  where T : class
{
    
}