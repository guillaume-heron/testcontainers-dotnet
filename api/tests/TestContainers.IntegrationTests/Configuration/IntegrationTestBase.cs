using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Infrastructure.Database;
using Xunit;

namespace TestContainers.IntegrationTests.Configuration;

[Collection(nameof(IntegrationTestCollectionDefinition))]
public abstract class IntegrationTestBase : IAsyncLifetime
{
    protected ISender Sender { get;  }
    protected ApplicationDbContext DbContext { get;  }
    protected DatabaseSeeder Seeder { get; }
    
    protected IntegrationTestBase(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        Seeder = new DatabaseSeeder(DbContext);
    }

    public async Task InitializeAsync()
    {
        await Seeder.SeedAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}