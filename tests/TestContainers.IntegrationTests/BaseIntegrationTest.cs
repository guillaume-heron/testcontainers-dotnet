using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Infrastructure.Database;
using Xunit;

namespace TestContainers.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly ISender Sender;
    protected readonly ApplicationDbContext DbContext;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }   
}