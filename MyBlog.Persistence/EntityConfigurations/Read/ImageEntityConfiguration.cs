using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Contracts.Articles.DTOS;

namespace MyBlog.Persistence.EntityConfigurations.Read;

public class ImageEntityConfiguration : IEntityTypeConfiguration<ImageDto>
{
    public void Configure(EntityTypeBuilder<ImageDto> builder)
    {
        builder.ToTable("articles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        builder.Property(x => x.Path)
            .IsRequired()
            .HasColumnName("path");
        builder.Property(x => x.IsMain)
            .IsRequired()
            .HasColumnName("is_main")
            .HasDefaultValue(false);
    }
}
