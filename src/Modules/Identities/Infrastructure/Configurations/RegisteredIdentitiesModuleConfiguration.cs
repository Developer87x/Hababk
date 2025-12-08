
using Hababk.Modules.Identities.Application.Queries;
using Hababk.Modules.Identities.Domain.Entities;
using Hababk.Modules.Identities.Infrastructure.Repositories;
using Hababk.Modules.Identities.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hababk.Modules.Identities.Infrastructure.Configurations
{
    public static class RegisteredIdentitiesModuleConfiguration
    {
        public static IServiceCollection RegisteredIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("defaultConnection");
            // Configuration code for the Identities module goes here
            services.AddDbContext<IdentitiesDbContext>(options =>
            {
                
                options.UseNpgsql(connectionString, s => s.MigrationsHistoryTable("__EFMigrationsHistory", "identity").EnableRetryOnFailure(3));
            });
            
            return services;
        }
        public static IServiceCollection RegisteredIdentityRepositoriesAndServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("defaultConnection");
            // Register repositories here
        
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserQueries>(_=> new UserQueries(connectionString));
            services.AddScoped<IPasswordHash, PasswordHashService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IRoleQueries>(_ => new RoleQueries(connectionString!));
            services.AddScoped<IRoleUserRepository,RoleUserRepository>();
            return services;
        }
    }
}