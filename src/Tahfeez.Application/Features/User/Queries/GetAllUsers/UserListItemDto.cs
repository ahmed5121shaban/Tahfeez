namespace Tahfeez.Application.Features.User.Queries.GetAllUsers;

public record UserListItemDto(
    Guid? Id,
    string? FullName,
    string? Email,
    DateTime? CreatedAt
);
