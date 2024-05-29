﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Persistence.DbContexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    [DbContext(typeof(AppWriteDbContext))]
    partial class AppWriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBlog.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("user_birth_date;");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("unknown")
                        .HasColumnName("user_first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("unknown")
                        .HasColumnName("user_last_name;");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_password_hash");

                    b.Property<DateTimeOffset>("RegistrationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("user_registration_date;");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("unknown")
                        .HasColumnName("user_second_name;");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "MyBlog.Domain.Entities.AppUser.Email#EmailObject", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Phone", "MyBlog.Domain.Entities.AppUser.Phone#Phone", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("phone_number");
                        });

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("AddedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("added_date");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Dislikes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("dislikes");

                    b.Property<int>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("likes");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_articles");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_articles_author_id");

                    b.ToTable("articles", (string)null);
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("AddedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid")
                        .HasColumnName("article_id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<int>("Dislikes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("dislikes");

                    b.Property<int>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("likes");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("id")
                        .HasName("pk_comments");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_comments_article_id");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_comments_author_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Article", b =>
                {
                    b.HasOne("MyBlog.Domain.Entities.AppUser", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("author_id");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Comment", b =>
                {
                    b.HasOne("MyBlog.Domain.Entities.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_articles_article_id");

                    b.HasOne("MyBlog.Domain.Entities.AppUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_comments_users_author_id");

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MyBlog.Domain.Entities.Article", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
