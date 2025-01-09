using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestContainers.Api.Application.UseCases.Articles.GetArticleById;
using TestContainers.Api.Domain.Articles;
using Xunit;

namespace TestContainers.UnitTests.Application;

public class GetArticleByIdTests
{
    [Fact]
    public async Task GetById_ShouldRetrieveNull_WhenArticleDoesNotExist()
    {
        // Arrange
        var articleRepositoryMock = Substitute.For<IArticleRepository>();
        var handler = new GetArticleByIdQueryHandler(articleRepositoryMock);
        
        var command = new GetArticleByIdQuery(Guid.NewGuid());

        articleRepositoryMock
            .GetByIdAsync(command.Id)
            .ReturnsNull();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public async Task GetById_ShouldRetrieveArticle_WhenArticleExists()
    {
        // Arrange
        var articleRepositoryMock = Substitute.For<IArticleRepository>();
        var handler = new GetArticleByIdQueryHandler(articleRepositoryMock);
        
        var article = Article.Create("Integration testing in .Net", "Guillaume H.", "...", true);
        var command = new GetArticleByIdQuery(article.Id);
        
        articleRepositoryMock
            .GetByIdAsync(command.Id)
            .Returns(article);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetById_ShouldCallRepository_WhenArticleIsRetrieved()
    {
        // Arrange
        var articleRepositoryMock = Substitute.For<IArticleRepository>();
        var handler = new GetArticleByIdQueryHandler(articleRepositoryMock);
        
        var article = Article.Create("Integration testing in .Net", "Guillaume H.", "...", true);
        var command = new GetArticleByIdQuery(article.Id);
        
        articleRepositoryMock
            .GetByIdAsync(command.Id)
            .Returns(article);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await articleRepositoryMock.Received(1).GetByIdAsync(Arg.Is<Guid>(x => x == command.Id));
    }
}