using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.Api.Application.UseCases.Articles.GetArticleById;
using TestContainers.IntegrationTests.Configuration;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

public class GetArticleByIdTests(IntegrationTestWebAppFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task GetById_ShouldReturnArticle_WhenArticleExists()
    {
        // Arrange
        var command = new CreateArticleCommand(
            "Test containers",
            "Guillaume H.",
            "This is an article about test containers",
            false);
        
        var articleId = await Sender.Send(command);
        var query = new GetArticleByIdQuery(articleId);
        
        // Act
        var article = await Sender.Send(query);
        
        // Asset
        Assert.NotNull(article);
    }
}