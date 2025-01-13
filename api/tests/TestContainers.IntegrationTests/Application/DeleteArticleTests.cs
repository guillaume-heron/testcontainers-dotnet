using TestContainers.Api.Application.UseCases.Articles.DeleteArticle;
using TestContainers.Api.Domain.Articles;
using TestContainers.IntegrationTests.Configuration;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

public class DeleteArticleTests(IntegrationTestWebAppFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Delete_ShouldThrowException_WhenArticleDoesNotExist()
    {
        // Arrange
        var dummyId = Guid.NewGuid();
        
        var command = new DeleteArticleCommand(dummyId);
        
        // Act
        Task Action() => Sender.Send(command);

        // Asset
        await Assert.ThrowsAsync<ArticleNotFoundException>(Action);
    }
    
    [Fact]
    public async Task Delete_ShouldDeleteArticle_WhenCommandIsValid()
    {
        // Arrange
        var dbArticle = Seeder.GetRandomArticle();
        
        var command = new DeleteArticleCommand(dbArticle.Id);
        
        // Act
        await Sender.Send(command);
        
        // Asset
        var article = DbContext.Articles.FirstOrDefault(a => a.Id == dbArticle.Id);
        
        Assert.Null(article);
    }
}