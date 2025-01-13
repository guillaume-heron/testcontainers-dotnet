using MediatR;

namespace TestContainers.Api.Application.UseCases.Articles.UpdateArticle;

public record UpdateArticleCommand(Guid Id, string Title, string Author, string Content, bool IsDraft) : IRequest;