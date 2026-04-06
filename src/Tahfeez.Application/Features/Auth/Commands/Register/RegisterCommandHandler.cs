using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using AppUser = Tahfeez.Domain.Entities.Users.User;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(UserManager<AppUser> userManager, ILogger<RegisterCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken = default)
        {
            var existing = await _userManager.FindByEmailAsync(request.Email);
            if (existing is not null)
                return Result.Failure("Email is already registered.");

            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                _logger.LogError("Failed to register user {Email}: {Errors}", request.Email, errors);
                return Result.Failure(errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role.ToString());
            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                _logger.LogError("Role assignment failed for {Email}: {Errors}", request.Email, errors);
                return Result.Failure(errors);
            }

            _logger.LogInformation("User {Email} registered successfully with role {Role}.", request.Email, request.Role);
            return Result.Success();
        }
    }
}
