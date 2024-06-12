using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;
using BC = BCrypt.Net;

namespace MyBlog.Application.Services.Users.Create;
public class CreateUserHandler : ICommandHandler<CreateUserRequest>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var passwordHash = BC.BCrypt.HashPassword(request.password);

        var createUserResult = AppUser.Create(
            request.userName,
            passwordHash,
            request.emailInput);

        if (createUserResult.IsFailure)
            return createUserResult.Error;

        return await _repository.Create(createUserResult.Value, cancellationToken);
    }
}
