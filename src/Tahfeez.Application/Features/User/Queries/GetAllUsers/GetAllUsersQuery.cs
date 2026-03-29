using MediatR;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<Result<IEnumerable<UserListItemDto>>>;
