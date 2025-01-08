using TestContainers.Api.Domain;

namespace TestContainers.Api.Infrastructure.Database.Repositories;

public abstract class Repository<TEntity>  where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }
}