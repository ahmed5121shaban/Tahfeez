namespace Tahfeez.Domain.Entities.User;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private User() { }

    public static User Create(string fullName, string email, string passwordHash)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }
}
