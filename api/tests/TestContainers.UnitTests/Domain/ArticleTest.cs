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
            author: "John Doe",
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
            author: "John Doe",
            content: "This is an article about test containers", 
            isDraft: false);
        
        // Assert
        Assert.NotNull(article.ReleaseDate);
    }
    
    [Fact]
    public void UpdatedArticle_ShouldHaveValidReleaseDate_WhenDraftIsSetFromFalseToTrue()
    {
        // Arrange 
        var article = Article.Create(
            title: "Test containers",
            author: "John Doe",
            content: "This is an article about test containers", 
            isDraft: false);
        
        // Act
        article.Update(article.Title, article.Author, article.Content, true);
        
        // Assert
        Assert.NotNull(article.ReleaseDate);
    }
}