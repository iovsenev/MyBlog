using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Queries.Users.GetUserById;

public class GetUserByIdHandler : ICommandHandler<GetUserByIdRequest, AppUserDto>
{
    private readonly AppReadDbContext _context;

    public GetUserByIdHandler(AppReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<AppUserDto, Error>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var userResult = await _context.Users.FindAsync(request.Id, cancellationToken);

        return userResult is null ? Errors.General.NotFound(request.Id) : userResult;
    }
}
