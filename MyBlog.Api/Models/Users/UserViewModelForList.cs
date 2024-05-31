namespace MyBlog.Api.Models.Users;

public record UserViewModelForList(
    Guid Id,
    string UserName,
    string FullName,
    DateTime BirthDate,
    DateTime RegisterDate);
