using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hababk.Modules.Identities.Application.Queries;
using Hababk.Modules.Identities.Domain.Entities;
using Hababk.Modules.Identities.Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class RegisteredIdentitiesModuleConfiguration
    {
        public static IServiceCollection RegisterdDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("defaultConnection");
            // Configuration code for the Identities module goes here
            services.AddDbContext<IdentitiesDbContext>(options =>
            {
                
                options.UseNpgsql(connectionString, s => s.MigrationsHistoryTable("__EFMigrationsHistory", "identity").EnableRetryOnFailure(3));
            });
            services.AddScoped<IUserQueries>(uq => new UserQueries(connectionString));
            return services;
        }
        public static IServiceCollection RegisterdRepositories(this IServiceCollection services)
        {
           services.AddScoped<IUserRepository, UserRepository>();
           return services;
        }
    }
}