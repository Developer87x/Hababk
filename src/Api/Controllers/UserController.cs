using Hababk.Modules.Identities.Application.Commands;
using Hababk.Modules.Identities.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hababk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator, IUserQueries userQueries) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IUserQueries _userQueries = userQueries;
    [HttpGet("GetUser/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userQueries.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet("GetUserByUserName/{userName}")]
    public async Task<IActionResult> GetByUserName(string userName)
    {
        var user =  await _userQueries.GetByUserNameAsync(userName);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> Get()
    {
        var users = await _userQueries.GetListAsync();
        return Ok(users);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}