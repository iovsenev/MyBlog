using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Users.Commands.Create;

public record CreateAppUserRequest(
    ) : IRequest<Guid>;
