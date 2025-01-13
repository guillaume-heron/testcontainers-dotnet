namespace TestContainers.Api.Contracts.Requests.Article;

public record UpdateArticleRequest(string Title, string Author, string Content, bool IsDraft) 
    : CreateOrUpdateArticleRequest(Title, Author, Content, IsDraft);