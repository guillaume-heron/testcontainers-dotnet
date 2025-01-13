namespace TestContainers.Api.Domain.Articles;

public sealed class Article : BaseEntity
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Content { get; private set; }
    public bool IsDraft { get; private set; }
    public DateOnly? ReleaseDate { get; private set; }

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

    public void Update(string title, string author, string content, bool isDraft)
    {
        Title = title;
        Author = author;
        Content = content;

        if (ReleaseDate is null && isDraft)
        {
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }
        
        IsDraft = isDraft;
    }
}