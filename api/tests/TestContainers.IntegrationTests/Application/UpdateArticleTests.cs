using TestContainers.Api.Application.UseCases.Articles.UpdateArticle;
using TestContainers.Api.Domain.Articles;
using TestContainers.IntegrationTests.Configuration;
using Xunit;

namespace TestContainers.IntegrationTests.Application;

public class UpdateArticleTests(IntegrationTestWebAppFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Update_ShouldThrowException_WhenArticleDoesNotExist()
    {
        // Arrange
        var dummyId = Guid.NewGuid();
        
        var command = new UpdateArticleCommand(
            Id: dummyId,
            Title: "Test containers",
            Author: "John Doe",
            Content: "This is an article about test containers",
            IsDraft: false);
        
        // Act
        Task Action() => Sender.Send(command);

        // Asset
        await Assert.ThrowsAsync<ArticleNotFoundException>(Action);
    }
    
    [Fact]
    public async Task Update_ShouldUpdateArticle_WhenCommandIsValid()
    {
        // Arrange
        var dbArticle = Seeder.GetRandomArticle();
        
        const string updatedContent = "updatedContent";
        
        var command = new UpdateArticleCommand(
            Id: dbArticle.Id,
            Title: dbArticle.Title,
            Author: dbArticle.Author,
            Content: updatedContent,
            IsDraft: dbArticle.IsDraft);
        
        // Act
        await Sender.Send(command);
        
        // Asset
        var article = DbContext.Articles.FirstOrDefault(a => a.Id == dbArticle.Id);
        
        Assert.NotNull(article);
        Assert.Equal(updatedContent, article.Content);
    }
}