using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Infrastructure.Database;
using Xunit;

namespace TestContainers.IntegrationTests.Configuration;

[Collection(nameof(IntegrationTestCollectionDefinition))]
public abstract class IntegrationTestBase
{
    protected ISender Sender { get;  }
    protected ApplicationDbContext DbContext { get;  }
    
    protected IntegrationTestBase(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }  
}