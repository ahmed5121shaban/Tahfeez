using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tahfeez.Domain.Entities.Users;
using Tahfeez.SharedKernal.Common;
namespace Tahfeez.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler: IRequestHandler<RegisterCommand, Result>
    {
        private readonly UserManager<Domain.Entities.Users.User> _userManager;
        public RegisterCommandHandler(UserManager<Domain.Entities.Users.User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken = default)
        {
            await _userManager.FindByEmailAsync(request.Email);
            throw new NotImplementedException();
        }
    }
}
