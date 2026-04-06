using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using Tahfeez.Api.Extentions;
using Tahfeez.Infrastracture.Persistence;

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

    // Register OpenIddict
    builder.AddOpenIddictConfig();

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddControllers();

    var app = builder.Build();

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
