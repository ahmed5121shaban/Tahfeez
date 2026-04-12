using Tahfeez.Domain.Entities.Roles;
using Tahfeez.Domain.Enums;

namespace Tahfeez.Application.Features.User.DTOs
{
    public record UpdateUserDto
    (
        string? userName,
        string? email,
        UserRole? role
    );
}
