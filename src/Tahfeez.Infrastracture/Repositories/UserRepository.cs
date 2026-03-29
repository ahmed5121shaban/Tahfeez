using Tahfeez.Domain.Entities.User;
using Tahfeez.Domain.Repositories;

namespace Tahfeez.Infrastracture.Repositories;

public class UserRepository : IUserRepository
{
    // TODO: Inject DbContext and implement
    
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task AddAsync(User user, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
