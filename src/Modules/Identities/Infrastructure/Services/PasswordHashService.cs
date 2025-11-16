
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Infrastructure.Services
{
    public class PasswordHashService : IPasswordHash
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}