
namespace Hababk.Modules.Identities.Domain.Entities;

public interface IAuthenticateService
{
    Task<bool> ValidateUserCredentials(string username, string password);
    Task<string> GenerateToken(string username);
}