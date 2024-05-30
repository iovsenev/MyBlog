namespace MyBlog.Api.Models.Users;

public record UserViewModel(
    Guid Id,
    string UserName,
    string FirstName,
    string SecondName,
    string LastName,
    DateTime BirthDate,
    DateTime RegisterDate);
