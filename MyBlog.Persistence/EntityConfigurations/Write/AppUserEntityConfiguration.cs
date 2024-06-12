using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Persistence.EntityConfigurations.Write;
public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
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
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnName("password_hash");
        builder.Property(p => p.Email)
            .HasColumnName("email")
            .IsRequired();
        builder.Property(u => u.RegistrationDate)
            .IsRequired()
            .HasColumnName("registration_date;");
        builder.Property(u => u.FirstName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("first_name");
        builder.Property(u => u.SecondName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("second_name;");
        builder.Property(u => u.LastName)
            .HasDefaultValue("")
            .IsRequired()
            .HasColumnName("last_name;");
        builder.Property(u => u.BirthDate)
            .HasColumnName("birth_date;");

        builder.ComplexProperty(u => u.Phone, p =>
        {
            p.Property(p => p.Phone).HasColumnName("phone_number");
        });


        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
