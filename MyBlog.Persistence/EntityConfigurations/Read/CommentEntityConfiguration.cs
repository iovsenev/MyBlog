using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentDto>
{
    public void Configure(EntityTypeBuilder<CommentDto> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);
    }
}
