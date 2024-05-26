using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.EntityConfigurations.Write;

public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
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
