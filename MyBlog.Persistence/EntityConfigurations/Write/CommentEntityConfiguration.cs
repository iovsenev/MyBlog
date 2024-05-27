using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.EntityConfigurations.Write;
public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.id);

        builder.Property(c => c.Text)
            .IsRequired()
            .HasColumnName("text");
        builder.Property(c => c.Likes)
            .IsRequired()
            .HasColumnName("likes")
            .HasDefaultValue(0);
        builder.Property(c => c.Dislikes)
            .IsRequired()
            .HasColumnName("dislikes")
            .HasDefaultValue(0);
        builder.Property(c => c.AddedDate)
            .HasColumnName("created_at");

        builder.HasOne(c => c.Author)
            .WithMany(u => u.Comments);

        builder.HasOne(c => c.Article)
            .WithMany(u => u.Comments);

    }
}
