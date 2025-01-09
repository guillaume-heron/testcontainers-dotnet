using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TestContainers.Api.Infrastructure.Database;
using Testcontainers.PostgreSql;
using Xunit;

namespace TestContainers.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = 
        new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("blogdb")
            .WithUsername("postgres")
            .WithUsername("postgres")
            .Build();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<ApplicationDbContext>>();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(_dbContainer.GetConnectionString()));
        });
    }
    
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }
    
    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}