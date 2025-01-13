using TestContainers.Api.Domain.Articles;
using TestContainers.Api.Infrastructure.Database;

namespace TestContainers.IntegrationTests.Configuration;

public sealed class DatabaseSeeder
{
    private readonly ApplicationDbContext _dbContext;
    
    private readonly List<Article> _articles = new();

    public DatabaseSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        SeedArticles();
        
        await _dbContext.SaveChangesAsync();
    }
    
    public Article GetRandomArticle()
    {
        var random = new Random();
        var index = random.Next(0, _articles.Count);
        
        return _articles[index];
    }

    
    #region Private methods
    
    private void SeedArticles()
    {
        var articles = new List<Article>()
        {
            Article.Create(
                "OpenAPI Documentation", "John Doe", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", true),
            Article.Create(
                "Hybrid Cache", "Kate Fox", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", true),
            Article.Create(
                "EF Core", "Neil Dixon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", false),
            Article.Create(
                "Clean Architecture", "Andrea Taylor", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", true),
            Article.Create(
                "Azure Aspire", "James Locke", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", false),
            Article.Create(
                "Dapper", "Juliet Cook", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", false),
            Article.Create(
                "Domain Driven Design", "Hugo Tucker", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quam turpis, aliquet non ultrices nec, aliquam a sem. Proin aliquet gravida ligula et lacinia. Vivamus pretium orci ac cursus posuere", true),
        };
        
        _articles.AddRange(articles);
        
        _dbContext.Articles.AddRange(_articles);
    }
    
    #endregion
}