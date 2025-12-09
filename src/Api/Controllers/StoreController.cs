using Hababk.Modules.Stores.Application.Commands;
using Hababk.Modules.Stores.Application.Queries;
using Hababk.Modules.Stores.Application.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hababk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController(IMediator mediator, IStoreQueries storeQueries) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IStoreQueries _storeQueries = storeQueries;

    [HttpGet("GetList")]
    public async Task<IActionResult> Get()
    {
        var stores =await _storeQueries.GetListAsync();
        return Ok(stores);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateStoreCommand command)
    {
        var validate = new CreateStoreCommandValidation();
        var validationResult = await validate.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage);
            return BadRequest(errors);
        }
        var result =await _mediator.Send(command);
        return Ok(result);
        
    }
}