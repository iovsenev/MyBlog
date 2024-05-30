using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.EntityConfigurations.Write;
public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.UserName)
            .IsUnique();
        //builder.HasIndex(u => u.Email)
        //    .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnName("user_password_hash");
        builder.Property(u => u.RegistrationDate)
            .IsRequired()
            .HasColumnName("user_registration_date;");
        builder.Property(u => u.FirstName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("user_first_name");
        builder.Property(u => u.SecondName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("user_second_name;");
        builder.Property(u => u.LastName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("user_last_name;");
        builder.Property(u => u.BirthDate)
            .IsRequired()
            .HasColumnName("user_birth_date;")
            .HasDefaultValue(DateTimeOffset.MinValue);

        builder.ComplexProperty(u => u.Phone, p =>
                p.Property(p => p.PhoneNumber)
                    .HasDefaultValue("+79998887766")
                    .HasColumnName("phone_number"));

        builder.ComplexProperty(u => u.Email, p =>{
            
                p.Property(p => p.Email)
                    .HasColumnName("email");}
                   );

        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
