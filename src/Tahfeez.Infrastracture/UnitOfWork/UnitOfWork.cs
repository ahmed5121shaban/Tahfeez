using Tahfeez.Domain.Repositories;

namespace Tahfeez.Infrastracture.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    // TODO: Inject DbContext and implement
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
