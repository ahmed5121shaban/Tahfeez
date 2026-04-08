using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Tahfeez.Application.Features.Auth.Commands.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tahfeez.Application.Features.Auth.Commands.Connect
{
    public class ConnectCommandHandler : IRequestHandler<ConnectCommand ,string>
    {
        Task<string> IRequestHandler<ConnectCommand, string>.Handle(ConnectCommand request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
