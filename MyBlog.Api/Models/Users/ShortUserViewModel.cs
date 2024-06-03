namespace MyBlog.Persistence.Repositories.Users.Queries;

public record ShortUserViewModel(
    Guid Id,
    string UserName,
    string FullName,
    DateTime BirthDate,
    DateTime RegisterDate);
