using MediatR;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDto>>;
