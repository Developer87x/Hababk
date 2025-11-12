using Hababk.Modules.Stores.Application.Queries;
using Hababk.Modules.Stores.Domain.Entities;
using Hababk.Modules.Stores.Infrastructure;
using Hababk.Modules.Stores.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ha
{
    public static  class RegisteredStoreModuleConfiguration
    {

        public static IServiceCollection AddStoreDbContext(this IServiceCollection storeServices, IConfiguration configuration)
        {
            // Configuration logic here
            storeServices.AddDbContext<StoreDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("defaultConnection"), s => s.MigrationsHistoryTable("__EFMigrationsHistory", "store").EnableRetryOnFailure(3)));
            storeServices.AddScoped<IStoreQueries>(sq => new StoreQueries(configuration.GetConnectionString("defaultConnection")));
            return storeServices;
        }
        
        public static IServiceCollection AddStoreRepositories(this IServiceCollection storeServices)
        {
            // Repository registration logic here
            storeServices.AddScoped<IStoreRepository, StoreRepository>();
            return storeServices;
        }
    }
}