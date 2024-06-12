using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class UserReadEntityConfiguration : IEntityTypeConfiguration<AppUserDto>
{
    public void Configure(EntityTypeBuilder<AppUserDto> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.UserName)
            .IsUnique();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.UserName)
            .HasColumnName("user_name");
        builder.Property(p => p.Email)
            .HasColumnName("email");
        builder.Property(u => u.RegistrationDate)
            .HasColumnName("user_registration_date;");
        builder.Property(u => u.FirstName)
            .HasColumnName("user_first_name");
        builder.Property(u => u.SecondName)
            .HasColumnName("user_second_name;");
        builder.Property(u => u.LastName)
            .HasColumnName("user_last_name;");
        builder.Property(u => u.BirthDate)
            .HasColumnName("user_birth_date;");

        builder.Property(u => u.Phone)
            .HasColumnName("phone_number")
            .HasDefaultValue(79998887766);

        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author);
    }
}
