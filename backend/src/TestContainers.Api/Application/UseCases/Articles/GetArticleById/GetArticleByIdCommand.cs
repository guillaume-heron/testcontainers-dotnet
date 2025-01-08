using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.GetArticleById;

public sealed record GetArticleByIdCommand(Guid Id) : IRequest<Article?>;