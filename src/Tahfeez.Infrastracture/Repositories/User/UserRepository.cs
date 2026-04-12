using Microsoft.EntityFrameworkCore;
using Tahfeez.Domain.Entities.Users;
using Tahfeez.Domain.Repositories;
using Tahfeez.Infrastracture.Persistence;

namespace Tahfeez.Infrastracture.Repositories;

public class UserRepository : IUserRepository
{
    // TODO: Inject DbContext and implement
    private readonly AppDbContext _context;
    private readonly DbSet<User> _userContext;
    public UserRepository(AppDbContext context)
    {
        _context = context;
        _userContext = _context.Users;
    }
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _userContext.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    => await _userContext.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<IEnumerable<User>> GetAllAsync(bool isDeleted = false, CancellationToken cancellationToken = default)
    => await _userContext.AsNoTracking().Where(u => u.IsDeleted == isDeleted).ToListAsync();
    
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    => await _userContext.AddAsync(user);
    

}
