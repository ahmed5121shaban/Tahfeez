using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tahfeez.Application.Features.User.Commands.DeleteUser;
using Tahfeez.Application.Features.User.DTOs;
using Tahfeez.Application.Features.User.Queries.GetAllUsers;
using Tahfeez.Application.Features.User.Queries.GetUserById;
using Tahfeez.Domain.Entities.Roles;
using Tahfeez.SharedKernal.Coonstants;

namespace Tahfeez.Api.Controllers.User;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete]
    public async Task<IActionResult> GetUserById([FromQuery] Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        return Ok(result);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto data)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(data));
        return CreatedAtAction( nameof (GetUserById));
    }
}
