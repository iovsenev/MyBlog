using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Application.Users.DTOS;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class UserEntityConfiguration : IEntityTypeConfiguration<AppUserDto>
{
    public void Configure(EntityTypeBuilder<AppUserDto> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);


        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.UserName)
            .HasColumnName("user_name");
        builder.Property(u => u.Email)
            .HasColumnName("email");
        builder.Property(u => u.FirstName)
            .HasColumnName("user_first_name");
        builder.Property(u => u.SecondName)
            .HasColumnName("user_second_name;");
        builder.Property(u => u.LastName)
            .HasColumnName("user_last_name;");
        builder.Property(u => u.BirthDate)
            .HasColumnName("user_birth_date;");
        builder.Property(u => u.RegistrationDate)
            .HasColumnName("user_registration_date;");

        builder.Property(p => p.Phone)
                    .HasColumnName("phone_number");

        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
