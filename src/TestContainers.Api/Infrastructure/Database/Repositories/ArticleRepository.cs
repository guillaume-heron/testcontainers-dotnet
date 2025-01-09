using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Infrastructure.Database.Repositories;

public sealed class ArticleRepository(ApplicationDbContext dbContext)
    : Repository<Article>(dbContext), IArticleRepository;