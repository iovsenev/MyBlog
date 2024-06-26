﻿namespace MyBlog.Domain.Entities.ReadEntity;

public class AppUserDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; } 
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SecondName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }

    public ICollection<ArticleDto> Articles { get; set; } = [];
    public ICollection<CommentDto> Comments { get; set; } = [];
}
