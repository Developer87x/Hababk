using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;
using Hababk.Modules.Identities.Infrastructure;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IdentitiesDbContext _dbContext;

        public UserRepository(IdentitiesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork =>_dbContext;

        public async Task<User> AddAsync(User user)
        {
            var entityEntry = await _dbContext.Users.AddAsync(user);
            return entityEntry.Entity;  
        }
    }
}