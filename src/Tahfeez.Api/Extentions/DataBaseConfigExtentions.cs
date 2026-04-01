using Microsoft.EntityFrameworkCore;
using Tahfeez.Infrastracture.Persistence;

namespace Tahfeez.Api.Extentions
{
    public static class DataBaseConfigExtentions
    {
        public static void AddDatabaseConfig(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseOpenIddict();
            });
        }
    }
}
