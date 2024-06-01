using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Queries.Users.GetAllUsers;
public class GetAllUsersHandler : IQueryHandler<AppUserDto>
{
    private readonly AppReadDbContext _context;

    public GetAllUsersHandler(AppReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<ICollection<AppUserDto>, Error>> Handle( CancellationToken ct)
    {
        var users = await _context.Users
            .ToListAsync();

        return new List<AppUserDto>(users);
    }
}
