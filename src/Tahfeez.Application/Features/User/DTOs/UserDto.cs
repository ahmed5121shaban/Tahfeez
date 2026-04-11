namespace Tahfeez.Application.Features.User.DTOs;

public record UserDto(
    Guid Id,
    string FullName,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
