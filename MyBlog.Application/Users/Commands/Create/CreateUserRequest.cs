using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Users.Commands.Create;

public record CreateUserRequest(
        string userName,
        string passwordHash,
        string emailInput,
        string phoneInput,
        string firstName,
        string lastName,
        string secondName,
        DateTime birthDate): IRequest<Guid>;
