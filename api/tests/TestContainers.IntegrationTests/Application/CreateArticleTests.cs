using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.IntegrationTests.Configuration;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

public class CreateArticleTests(IntegrationTestWebAppFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Create_ShouldAddNewArticle_WhenCommandIsValid()
    {
        // Arrange
        var command = new CreateArticleCommand(
            "Test containers",
            "John Doe",
            "This is an article about test containers",
            false);
        
        // Act
        var articleId = await Sender.Send(command);
        
        // Asset
        var article = DbContext.Articles.FirstOrDefault(a => a.Id == articleId);
        
        Assert.NotNull(article);
    }
}