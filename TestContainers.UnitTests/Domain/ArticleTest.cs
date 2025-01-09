using TestContainers.Api.Domain.Articles;
using Xunit;

namespace TestContainers.UnitTests.Domain;

public class ArticleTest
{
    [Fact]
    public void NewArticle_ShouldHaveNullReleaseDate_WhenIsDraft()
    {
        // Arrange 
        var article = Article.Create(
            title: "Test containers",
            author: "Guillaume H.",
            content: "This is an article about test containers", 
            isDraft: true);
        
        // Assert
        Assert.Null(article.ReleaseDate);
    }
    
    [Fact]
    public void NewArticle_ShouldHaveValidReleaseDate_WhenIsNotDraft()
    {
        // Arrange 
        var article = Article.Create(
            title: "Test containers",
            author: "Guillaume H.",
            content: "This is an article about test containers", 
            isDraft: false);
        
        // Assert
        Assert.NotNull(article.ReleaseDate);
    }
}