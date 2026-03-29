using Microsoft.Extensions.DependencyInjection;
using Tahfeez.Domain.Repositories;
using Tahfeez.Infrastracture.Repositories;
using Tahfeez.Infrastracture.UnitOfWork;

namespace Tahfeez.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
