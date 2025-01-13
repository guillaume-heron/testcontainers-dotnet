using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.UpdateArticle;

public sealed class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleRepository _articleRepository;

    public UpdateArticleCommandHandler(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
    {
        _unitOfWork = unitOfWork;
        _articleRepository = articleRepository;
    }
    
    public async Task Handle(
        UpdateArticleCommand command,
        CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (article is null)
        {
            throw new ArticleNotFoundException(command.Id);
        }

        article.Update(command.Title, command.Author, command.Content, command.IsDraft);

        _articleRepository.Update(article);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}