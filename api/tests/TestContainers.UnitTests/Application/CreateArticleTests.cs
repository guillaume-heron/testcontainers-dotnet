using NSubstitute;
using TestContainers.Api.Application;
using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.Api.Domain.Articles;
using Xunit;

namespace TestContainers.UnitTests.Application;

public class CreateArticleTests
{
    [Fact]
    public async Task Create_ShouldReturnArticleId_WhenCommandIsValid()
    {
        // Arrange
        var handler = new CreateArticleCommandHandler(
            unitOfWork: Substitute.For<IUnitOfWork>(), 
            articleRepository: Substitute.For<IArticleRepository>());

        var command = new CreateArticleCommand(
            Title: "Test containers",
            Author: "John Doe",
            Content: "This is an article about test containers",
            IsDraft: true);

        // Act
        var articleId = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(articleId, Guid.Empty);
    }
    
    [Fact]
    public async Task Create_ShouldCallRepository_WhenArticleIsCreated()
    {
        // Arrange
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var articleRepositoryMock = Substitute.For<IArticleRepository>();
        
        var handler = new CreateArticleCommandHandler(unitOfWorkMock, articleRepositoryMock);

        var command = new CreateArticleCommand(
            Title: "Test containers",
            Author: "John Doe",
            Content: "This is an article about test containers",
            IsDraft: true);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        articleRepositoryMock.Received(1).Add(Arg.Any<Article>());
        await unitOfWorkMock.Received(1).SaveChangesAsync();
    }
}