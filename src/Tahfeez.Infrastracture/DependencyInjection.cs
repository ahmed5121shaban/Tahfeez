using Microsoft.Extensions.DependencyInjection;
using Tahfeez.Domain.Repositories;
using Tahfeez.Infrastracture.Persistence.Seeders;
using Tahfeez.Infrastracture.Repositories;

namespace Tahfeez.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
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
