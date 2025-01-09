using TestContainers.Api.Application.UseCases.Articles;

namespace TestContainers.Api.Application.UseCases;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapArticlesEndpoints();
    }
}