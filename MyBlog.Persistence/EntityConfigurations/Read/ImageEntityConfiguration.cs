using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Contracts.Images.DTOS;

namespace MyBlog.Persistence.EntityConfigurations.Read;

public class ImageEntityConfiguration : IEntityTypeConfiguration<ImageDto>
{
    public void Configure(EntityTypeBuilder<ImageDto> builder)
    {
        builder.ToTable("articles");
        builder.HasKey(x => x.Id);
    }
}
