namespace Tahfeez.Application.Features.User.Queries.GetUserById;

public record UserDto(
    Guid Id,
    string FullName,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
