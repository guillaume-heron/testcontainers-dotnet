using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.DeleteArticle;

public sealed class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleRepository _articleRepository;

    public DeleteArticleCommandHandler(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
    {
        _unitOfWork = unitOfWork;
        _articleRepository = articleRepository;
    }
    
    public async Task Handle(
        DeleteArticleCommand command,
        CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (article is null)
        {
            throw new ArticleNotFoundException(command.Id);
        }

        _articleRepository.Delete(article);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}