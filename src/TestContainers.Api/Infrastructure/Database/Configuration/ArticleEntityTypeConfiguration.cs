using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestContainers.Api.Domain.Articles;

namespace TestContainers.Api.Infrastructure.Database.Configuration;

public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("articles", "blog")
            .HasKey(m => m.Id);

        builder.Property(b => b.Id)
            .HasColumnName("id");
        
        builder.Property(b => b.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(b => b.Author)
            .HasColumnName("author")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(b => b.Content)
            .HasColumnName("content")
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(b => b.IsDraft)
            .HasColumnName("isDraft")
            .HasDefaultValue(false);
        
        builder.Property(b => b.ReleaseDate)
            .HasColumnName("releaseDate");
    }
}