namespace TestContainers.Api.Domain.Articles;

public sealed class Article : BaseEntity
{
    public string Title { get; init; }
    public string Author { get; init; }
    public string Content { get; init; }
    public bool IsDraft { get; init; }
    public DateOnly? ReleaseDate { get; init; }

    private Article(string title, string author, string content, bool isDraft)
    {
        Id = Guid.NewGuid();
        
        Title = title;
        Author = author;
        Content = content;
        IsDraft = isDraft;
        ReleaseDate = isDraft ? null : DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public static Article Create(string title, string author, string content, bool isDraft) =>
        new(title, author, content, isDraft);
}