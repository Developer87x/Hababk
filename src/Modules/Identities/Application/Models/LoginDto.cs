namespace Hababk.Modules.Identities.Application.Models;

public class LoginDto
{

    public required string? UserName { get; set; }

    public required string? Password { get; set; }
}