using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

public class CreateArticleTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
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
        var articleId = await Sender.Send(command);
        
        // Asset
        var article = DbContext.Articles.FirstOrDefault(a => a.Id == articleId);
        
        Assert.NotNull(article);
    }
}