using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Persistence.EntityConfigurations.Write;
public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tags");

        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Id)
            .HasColumnName("id");
        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("tag_name");

        builder.HasMany(t => t.Articles)
            .WithMany(t => t.Tags);
    }
}
