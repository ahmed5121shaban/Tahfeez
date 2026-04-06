using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Tahfeez.Domain.Entities.Roles;
using Tahfeez.Domain.Entities.Users;
using Tahfeez.Domain.Repositories;
using Tahfeez.Infrastracture.Persistence;
using Tahfeez.Infrastracture.Persistence.Seeders;
using Tahfeez.Infrastracture.Repositories;

namespace Tahfeez.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Identity (must be registered before OpenIddict)
        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.User.RequireUniqueEmail = true;
        })
        .AddRoles<Role>()
        .AddEntityFrameworkStores<AppDbContext>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Seeders
        services.AddScoped<RolesSeeder>();
        services.AddScoped<UsersSeeder>();
        services.AddScoped<OpeniddictSeeder>();
        services.AddSingleton<DatabaseSeeder>();

        return services;
    }
}
