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

        //var entity = await _repository.Users
        //    .FirstOrDefaultAsync(u => u.UserName == request.userName ||
        //                u.Email.Email == request.emailInput);

        //if (entity is not null)
        //    return Errors.General.AlreadyExists();

        var createUserResult = AppUser.Create(
            request.userName,
            passwordHash,
            request.emailInput);


        if (createUserResult.IsFailure)
            return createUserResult.Error;

        return await _repository.Create(createUserResult.Value, cancellationToken);
    }
}
