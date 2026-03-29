using Tahfeez.Domain.Entities.User;

namespace Tahfeez.Application.Interfaces.User;

public interface IUserService
{
    Task<Domain.Entities.User.User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Domain.Entities.User.User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Domain.Entities.User.User> CreateAsync(string fullName, string email, string password, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, string fullName, string email, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
