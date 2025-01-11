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
        var random = new Random();
        var index = random.Next(0, Seeder.ArticlesCount);
        var dbArticle = Seeder.GetExistingArticle(index);
        
        var query = new GetArticleByIdQuery(dbArticle.Id);
        
        // Act
        var article = await Sender.Send(query);
        
        // Asset
        Assert.NotNull(article);
        Assert.Equal(dbArticle.Id, article.Id);
    }
    
    [Fact]
    public async Task GetById_ShouldReturnNull_WhenArticleDoesNotExist()
    {
        // Arrange
        var dummyId = Guid.NewGuid();
        var query = new GetArticleByIdQuery(dummyId);
        
        // Act
        var article = await Sender.Send(query);
        
        // Asset
        Assert.Null(article);
    }
}