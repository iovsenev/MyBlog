using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Repositories.Users.Queries.GetUserById;
public class GetUserByIdQuery : IQueryHandler<Guid, AppUserDto>
{
    private readonly AppReadDbContext _context;

    public GetUserByIdQuery (AppReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<AppUserDto, Error>> Handle(Guid request, CancellationToken ct)
    {
        var user = await _context.Users
            .Include(user => user.Comments)
            .Include(user => user.Articles)
            .FirstOrDefaultAsync(user => user.Id == request);

        if (user is null)
            return Errors.General.NotFound($"User with id {request} not found.");

        return user;
    }
}
