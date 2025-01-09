using TestContainers.Api.Application;
using TestContainers.Api.Application.UseCases;
using TestContainers.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.MapOpenApi();
app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();