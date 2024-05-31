using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities;
using BC = BCrypt.Net;

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
        var passwordHash = BC.BCrypt.HashPassword(request.password);

        var entity = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == request.userName ||
                        u.Email.Email == request.emailInput);

        if (entity is not null)
            return Errors.General.AlreadyExists();

        var result = AppUser.Create(
            request.userName,
            passwordHash,
            request.emailInput);


        if (result.IsFailure)
            return result.Error;


        await _context.Users.AddAsync(result.Value, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
