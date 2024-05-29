using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Application.Comments.Dtos;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class CommentEntityConfiguration : IEntityTypeConfiguration<GetCommentDto>
{
    public void Configure(EntityTypeBuilder<GetCommentDto> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);
    }
}
