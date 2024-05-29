
using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Users.Commands.Create;

public class CreateUserHandler : ICommandHandler<CreateUserRequest, Guid>
{
    private readonly IWriteDbContext _context;

    public CreateUserHandler(IWriteDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Error>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = AppUser.Create(
            request.userName,
            request.passwordHash,
            request.emailInput,
            request.phoneInput,
            request.firstName,
            request.lastName,
            request.secondName,
            request.birthDate);

        if (result.IsFailure)
            return result.Error;

        await _context.Users.AddAsync(result.Value, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
