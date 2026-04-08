using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tahfeez.Application.Features.Auth.Commands.Connect
{
    public record ConnectCommand
    (
    ) : IRequest<string>;
}
