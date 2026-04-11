using System;
using System.Collections.Generic;
using System.Text;

namespace Tahfeez.Application.Features.User.DTOs
{
    public record UpdateUserDto
    (
        Guid id,
        string userName,
        string email,
        string password
    );
}
