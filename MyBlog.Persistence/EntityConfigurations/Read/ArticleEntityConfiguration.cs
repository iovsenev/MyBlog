using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Contracts.Articles.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class ArticleEntityConfiguration : IEntityTypeConfiguration<ArticleDto>
{
    public void Configure(EntityTypeBuilder<ArticleDto> builder)
    {
        builder.ToTable("articles");

        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.Comments)
            .WithOne()
            .HasForeignKey(c => c.Id);

        builder.HasMany(a => a.Images)
            .WithOne()
            .HasForeignKey(i => i.Id);
    }
}
