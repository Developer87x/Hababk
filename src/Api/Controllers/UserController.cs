using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hababk.Modules.Identities.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator, IUserQueries userQueries) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IUserQueries _userQueries = userQueries;
    }
}