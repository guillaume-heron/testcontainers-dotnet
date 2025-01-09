using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.GetArticleById;

public sealed class GetArticleByIdCommandHandler : IRequestHandler<GetArticleByIdCommand, Article?>
{
    private readonly IArticleRepository _articleRepository;

    public GetArticleByIdCommandHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Article?> Handle(GetArticleByIdCommand command, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetByIdAsync(command.Id);
    }
}