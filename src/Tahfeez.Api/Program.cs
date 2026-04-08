using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using Tahfeez.Api.Extentions;
using Tahfeez.Application;
using Tahfeez.Infrastracture;
using Tahfeez.Infrastracture.Persistence;
using Tahfeez.Infrastracture.Persistence.Seeders;

// Bootstrap logger for startup errors (before config/DI is built)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Tahfeez API...");

    var builder = WebApplication.CreateSlimBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Configure Serilog from appsettings.json
    builder.Host.UseSerilog((context, services, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
                     .ReadFrom.Services(services)
                     .Enrich.FromLogContext());

    // Register the database
    builder.AddDatabaseConfig(connectionString);

    // Register services
    builder.AddDiContainer();

    // Register Infrastructure (Identity + repos + seeders) — must be before OpenIddict
    builder.Services.AddInfrastructure();

    // Register OpenIddict (after Identity)
    builder.AddOpenIddictConfig();

    // Register Application (MediatR)
    builder.Services.AddApplication();

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddControllers();

    var app = builder.Build();

    // Seed the database on startup
    await using (var scope = app.Services.CreateAsyncScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureCreatedAsync();
    }
    var seeder = app.Services.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    // Log every HTTP request/response
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Tahfeez API terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
