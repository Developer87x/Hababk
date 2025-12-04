using Application.Validation;
using Domain.Entities;
using Hababk.Modules.Identities.Application.Dtos;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hababk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IAuthenticateService authenticateService) : ControllerBase
{
    private readonly IAuthenticateService _authenticateService = authenticateService;
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var userValidator = new  UserValidator();
        var validationResult = userValidator.Validate(login);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }   
        var result = await _authenticateService.ValidateUserCredentials(login.UserName!, login.Password!);
        if (!result)
        {
            return Unauthorized("Invalid username or password.");
        }
        var token = await _authenticateService.GenerateToken(login.UserName!);
        return Ok(token);
    }
}