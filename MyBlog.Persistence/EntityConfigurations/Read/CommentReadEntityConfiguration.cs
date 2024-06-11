using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class CommentReadEntityConfiguration : IEntityTypeConfiguration<CommentDto>
{
    public void Configure(EntityTypeBuilder<CommentDto> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

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
