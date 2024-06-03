﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.EntityConfigurations.Read;
public class UserEntityConfiguration : IEntityTypeConfiguration<AppUserDto>
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
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(p => p.Email)
                    .HasColumnName("email")
                    .IsRequired();
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

        builder.Property(u => u.Phone)
                    .HasColumnName("phone_number");

        //builder.ComplexProperty(u => u.Phone, p =>
        //        p.Property(p => p)
        //            .HasDefaultValue("+79998887766")
        //            .HasColumnName("phone_number"));


        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author);
    }
}
