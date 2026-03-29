using MediatR;
using Tahfeez.Domain.Repositories;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);
        if (exists)
            return Result.Failure<Guid>("A user with this email already exists.");

        // TODO: Hash password properly
        var passwordHash = request.Password;

        var user = Domain.Entities.User.User.Create(request.FullName, request.Email, passwordHash);

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
