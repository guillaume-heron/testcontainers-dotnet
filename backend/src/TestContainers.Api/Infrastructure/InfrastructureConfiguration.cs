using Microsoft.EntityFrameworkCore;
using TestContainers.Api.Application;
using TestContainers.Api.Domain.Articles;
using TestContainers.Api.Infrastructure.Database;
using TestContainers.Api.Infrastructure.Database.Repositories;

namespace TestContainers.Api.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDatabase(configuration);

        return services;
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        dbContext.Database.Migrate();
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}