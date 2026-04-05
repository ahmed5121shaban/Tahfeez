using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tahfeez.Api.Extentions;
using Tahfeez.Infrastracture.Persistence;

var builder = WebApplication.CreateSlimBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

app.UseAuthentication();
app.UseAuthentication();

app.MapControllers();

app.Run();

