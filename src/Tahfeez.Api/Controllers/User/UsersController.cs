using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tahfeez.Application.Features.User.Queries.GetAllUsers;
using Tahfeez.Domain.Entities.Roles;
using Tahfeez.SharedKernal.Coonstants;

namespace Tahfeez.Api.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }
}
