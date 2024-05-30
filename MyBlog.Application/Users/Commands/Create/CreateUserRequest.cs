using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Users.Commands.Create;

public record CreateUserRequest(
        string userName,
        string password,
        string emailInput) : IRequest<Guid>;
