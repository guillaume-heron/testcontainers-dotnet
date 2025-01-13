using MediatR;

namespace TestContainers.Api.Application.UseCases.Articles.DeleteArticle;

public record DeleteArticleCommand(Guid Id) : IRequest;