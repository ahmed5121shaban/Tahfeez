using MediatR;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand(
        Guid id,
        string userName,
        string email,
        string password
) : IRequest<Result>;
