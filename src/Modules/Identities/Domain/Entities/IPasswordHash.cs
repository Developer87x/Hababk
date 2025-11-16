namespace Hababk.Modules.Identities.Domain.Entities
{
    public interface IPasswordHash
    {
        string HashPassword(string password);
        bool VerifyPassword(string plainPassword, string hashedPassword);
    }
}