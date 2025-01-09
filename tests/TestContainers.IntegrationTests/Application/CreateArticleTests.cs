using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.Api.Infrastructure.Database;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

[Collection(nameof(IntegrationTestCollectionDefinition))]
public class CreateArticleTests
{
    private readonly ISender _sender;
    private readonly ApplicationDbContext _dbContext;
    
    public CreateArticleTests(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        _sender = scope.ServiceProvider.GetRequiredService<ISender>();
        _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }  
    
    [Fact]
    public async Task Create_ShouldAddNewArticle_WhenCommandIsValid()
    {
        // Arrange
        var command = new CreateArticleCommand(
            "Test containers",
            "Guillaume H.",
            "This is an article about test containers",
            false);
        
        // Act
        var articleId = await _sender.Send(command);
        
        // Asset
        var article = _dbContext.Articles.FirstOrDefault(a => a.Id == articleId);
        
        Assert.NotNull(article);
    }
}