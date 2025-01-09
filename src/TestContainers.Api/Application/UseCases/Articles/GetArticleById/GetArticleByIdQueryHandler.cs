using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.GetArticleById;

public sealed class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article?>
{
    private readonly IArticleRepository _articleRepository;

    public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Article?> Handle(GetArticleByIdQuery query, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetByIdAsync(query.Id);
    }
}