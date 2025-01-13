namespace TestContainers.Api.Domain.Articles;

public sealed class ArticleNotFoundException(Guid id) : Exception($"Article with id: {id} was not found");