using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Infrastructure.Database;
using Xunit;

namespace TestContainers.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    protected ISender Sender { get; }
    protected ApplicationDbContext DbContext { get; }
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }   
}