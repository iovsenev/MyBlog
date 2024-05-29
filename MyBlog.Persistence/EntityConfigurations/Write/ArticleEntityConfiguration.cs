using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.EntityConfigurations.Write;

public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("articles");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("id");
        builder.Property(a => a.Title)
            .IsRequired()
            .HasColumnName("title");
        builder.Property(a => a.Description)
            .IsRequired()
            .HasColumnName("description");
        builder.Property(a => a.Text)
            .HasColumnName("text")
            .IsRequired();
        builder.Property(a => a.AddedDate)
            .HasColumnName("added_date");
        builder.Property(a => a.Likes)
            .HasColumnName("likes")
            .HasDefaultValue(0);
        builder.Property(a => a.Dislikes)
            .HasColumnName("dislikes")
            .HasDefaultValue(0);

        builder.HasMany(a => a.Comments)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Images)
            .WithOne(i => i.Article)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Author)
            .WithMany(U => U.Articles)
            .HasConstraintName("author_id");

    }
}
