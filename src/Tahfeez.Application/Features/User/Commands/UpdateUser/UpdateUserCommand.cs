using MediatR;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    string FullName,
    string Email
) : IRequest<Result>;
