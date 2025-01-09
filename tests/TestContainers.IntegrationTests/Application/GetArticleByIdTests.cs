using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.Api.Application.UseCases.Articles.GetArticleById;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

[Collection(nameof(IntegrationTestCollectionDefinition))]
public class GetArticleByIdTests
{
    private readonly ISender _sender;
    
    public GetArticleByIdTests(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        _sender = scope.ServiceProvider.GetRequiredService<ISender>();
    }  
    
    [Fact]
    public async Task GetById_ShouldReturnArticle_WhenArticleExists()
    {
        // Arrange
        var command = new CreateArticleCommand(
            "Test containers",
            "Guillaume H.",
            "This is an article about test containers",
            false);
        
        var articleId = await _sender.Send(command);
        var query = new GetArticleByIdQuery(articleId);
        
        // Act
        var article = await _sender.Send(query);
        
        // Asset
        Assert.NotNull(article);
    }
}