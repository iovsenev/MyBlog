using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.EntityConfigurations
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("title");
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description");
            builder.Property(x => x.Text)
                .HasColumnName("text")
                .IsRequired();
            builder.Property(x => x.AddedDate)
                .HasColumnName("added_date");
            builder.Property(x => x.Likes)
                .HasColumnName("likes")
                .HasDefaultValue(0);
            builder.Property(x=> x.Dislikes)
                .HasColumnName("dislikes")
                .HasDefaultValue(0);

        }
    }
}
