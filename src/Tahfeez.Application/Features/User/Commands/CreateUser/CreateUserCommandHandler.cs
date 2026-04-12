using MediatR;
using Tahfeez.Domain.Repositories;
using Tahfeez.SharedKernal.Common;
using Tahfeez.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Tahfeez.Domain.Entities.Roles;
namespace Tahfeez.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Domain.Entities.Users.User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, UserManager<Domain.Entities.Users.User> userManager, RoleManager<Role> roleManager)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userManager.FindByEmailAsync(request.userDto.Email) != null;
        if (exists)
            return Result.Failure<Guid>("A user with this email already exists.");

        var user =new Domain.Entities.Users.User
        {
            Email = request.userDto.Email,
            UserName = request.userDto.UserName,
            EmailConfirmed = true,
        };

        var createResult = await _userManager.CreateAsync(user, request.userDto.Password);
        if( !createResult.Succeeded)
            return Result.Failure<Guid>("Failed to create user.");

        await _userManager.AddToRoleAsync(user, "User");

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
