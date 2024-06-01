using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Services.Users.Create;

public record CreateUserRequest(
        string userName,
        string password,
        string emailInput);
