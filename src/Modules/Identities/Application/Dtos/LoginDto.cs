using System.ComponentModel.DataAnnotations;

namespace Hababk.Modules.Identities.Application.Dtos;

public class LoginDto
{

    required public string? UserName { get; set; }

    required public string? Password { get; set; }
}