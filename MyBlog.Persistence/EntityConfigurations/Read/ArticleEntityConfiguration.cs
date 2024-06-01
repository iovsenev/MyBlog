using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class ArticleEntityConfiguration : IEntityTypeConfiguration<ArticleDto>
{
    public void Configure(EntityTypeBuilder<ArticleDto> builder)
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
