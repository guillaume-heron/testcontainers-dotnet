using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestContainers.Api.Application.UseCases.Articles.CreateArticle;
using TestContainers.Api.Application.UseCases.Articles.GetArticleById;
using TestContainers.Api.Contracts.Requests.Article;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Application.UseCases.Articles;

public static class ArticlesEndpoints
{
    public static void MapArticlesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/articles")
            .WithTags("Articles")
            .WithOpenApi();
        
        group.MapGet("{id:guid}", GetArticleById)
            .WithName(nameof(GetArticleById))
            .WithSummary("Retrieve an article by id");
        
        group.MapPost("", CreateArticle)
            .WithName(nameof(CreateArticle))
            .WithSummary("Create a new article");
    }
    
    private static async Task<Results<Ok<Article>, NotFound>> GetArticleById(
        [FromRoute] Guid id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetArticleByIdQuery(id);

        var article = await sender.Send(query, cancellationToken);

        return article is null ? TypedResults.NotFound() : TypedResults.Ok(article);
    }

    private static async Task<CreatedAtRoute> CreateArticle(
        [FromBody] CreateArticleRequest request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new CreateArticleCommand(request.Title, request.Author, request.Content, request.IsDraft);
    
        var articleId = await sender.Send(command, cancellationToken);
    
        return TypedResults.CreatedAtRoute(routeName: "GetArticleById" , routeValues: new { id = articleId });
    }
}