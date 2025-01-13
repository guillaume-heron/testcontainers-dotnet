using NSubstitute;
using TestContainers.Api.Application;
using TestContainers.Api.Application.UseCases.Articles.DeleteArticle;
using TestContainers.Api.Domain.Articles;
using Xunit;

namespace TestContainers.UnitTests.Application;

public class DeleteArticleTests
{
    [Fact]
    public async Task DeleteHandler_ShouldCallRepositoryOnce_WhenArticleExists()
    {
        // Arrange
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var articleRepositoryMock = Substitute.For<IArticleRepository>();
        
        var handler = new DeleteArticleCommandHandler(unitOfWorkMock, articleRepositoryMock);

        var article = Article.Create(
            title: "Test containers",
            author: "John Doe",
            content: "This is an article about test containers",
            isDraft: true);

        var command = new DeleteArticleCommand(article.Id);

        articleRepositoryMock
            .GetByIdAsync(command.Id)
            .Returns(article);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await articleRepositoryMock
            .Received(1)
            .GetByIdAsync(Arg.Is<Guid>(x => x == command.Id));
        
        articleRepositoryMock
            .Received(1)
            .Delete(Arg.Any<Article>());

        await unitOfWorkMock
            .Received(1)
            .SaveChangesAsync();
    }
}