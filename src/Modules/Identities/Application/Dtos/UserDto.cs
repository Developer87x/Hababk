using System.Runtime.Serialization;

namespace Hababk.Modules.Identities.Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
}
