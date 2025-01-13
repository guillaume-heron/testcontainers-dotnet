using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestContainers.Api.Contracts.Requests.Article;

public record CreateOrUpdateArticleRequest(
    [property: Required]
    [property: MaxLength(100)]
    [property: Description("The title of the article")]
    string Title, 
    
    [property: Required]
    [property: MaxLength(100)]
    [property: Description("The name of the author")]
    string Author, 
    
    [property: Required]
    [property: MaxLength(500)]
    [property: Description("The content of the article")]
    string Content, 
    
    [property: Description("Whether the article is in draft mode or not")]
    bool IsDraft);