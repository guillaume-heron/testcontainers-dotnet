using MediatR;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles.CreateArticle;

public sealed class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleRepository _articleRepository;

    public CreateArticleCommandHandler(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
    {
        _unitOfWork = unitOfWork;
        _articleRepository = articleRepository;
    }
    
    public async Task<Guid> Handle(
        CreateArticleCommand command,
        CancellationToken cancellationToken)
    {
        var article = Article.Create(command.Title, command.Author, command.Content, command.IsDraft);

        _articleRepository.Add(article);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return article.Id;
    }
}