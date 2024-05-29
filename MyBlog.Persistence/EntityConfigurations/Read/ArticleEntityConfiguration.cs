using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Application.Articles.Dtos;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class ArticleEntityConfiguration : IEntityTypeConfiguration<GetArticleDto>
{
    public void Configure(EntityTypeBuilder<GetArticleDto> builder)
    {
        builder.ToTable("articles");

        builder.HasKey(a => a.Id);

        //builder.HasMany(a => a.Comments)
        //    .WithOne()
        //    .HasForeignKey(c => c.Article);

        //builder.HasMany(a => a.Images)
        //    .WithOne()
        //    .HasForeignKey(i => i.Id);
    }
}
