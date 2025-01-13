namespace TestContainers.Api.Domain.Articles;

public interface IArticleRepository
{
    Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Article article);
    void Update(Article article);
    void Delete(Article article);
}