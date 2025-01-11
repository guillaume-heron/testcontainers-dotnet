using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.GetArticleById;

public sealed record GetArticleByIdQuery(Guid Id) : IRequest<Article?>;