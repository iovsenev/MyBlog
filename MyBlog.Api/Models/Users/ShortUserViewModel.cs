namespace MyBlog.Api.Models.Users;

public record ShortUserViewModel(
    Guid Id,
    string UserName,
    string FullName,
    DateTime BirthDate,
    DateTime RegisterDate);
