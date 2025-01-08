using MediatR;

namespace TestContainers.Api.Application.UseCases.Articles.CreateArticle;

public record CreateArticleCommand(string Title, string Author, string Content, bool IsDraft): IRequest<Guid>;