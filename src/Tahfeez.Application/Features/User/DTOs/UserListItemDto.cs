namespace Tahfeez.Application.Features.User.DTOs;

public record UserListItemDto(
    Guid Id,
    string FullName,
    string Email,
    DateTime CreatedAt
);
