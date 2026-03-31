using MediatR;
using Tahfeez.Domain.Repositories;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserListItemDto>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IEnumerable<UserListItemDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        var dtos = users.Select(u => new UserListItemDto(u.Id, FullName:"", Email:"FullName", u.CreatedAt));
        return Result.Success(dtos);
    }
}
