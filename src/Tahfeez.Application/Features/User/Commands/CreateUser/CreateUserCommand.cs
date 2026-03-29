using MediatR;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Commands.CreateUser;

public record CreateUserCommand(
    string FullName,
    string Email,
    string Password
) : IRequest<Result<Guid>>;
