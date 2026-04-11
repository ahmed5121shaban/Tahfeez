using MediatR;
using Tahfeez.Application.Features.User.DTOs;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand(UpdateUserDto user) : IRequest<Result>;