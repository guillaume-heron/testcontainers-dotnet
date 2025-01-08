namespace TestContainers.Api.Domain.Articles;

public interface IArticleRepository
{
    Task<Article?> GetByIdAsync(Guid id);
    void Add(Article article);
}