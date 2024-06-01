using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class UserEntityConfiguration : IEntityTypeConfiguration<AppUserDto>
{
    public void Configure(EntityTypeBuilder<AppUserDto> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);


        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
