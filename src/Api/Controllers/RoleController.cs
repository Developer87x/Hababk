using Hababk.Modules.Identities.Application.Commands;
using Hababk.Modules.Identities.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hababk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRoleQueries _roleQueries;

    public RoleController(IMediator mediator, IRoleQueries roleQueries)
    {
        _mediator = mediator;
        _roleQueries = roleQueries;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("GetRoleByName/{roleName}")]
    public async Task<IActionResult> GetRoleByName(string roleName)
    {
        var role = await _roleQueries.GetRoleByNameAsync(roleName);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }
}