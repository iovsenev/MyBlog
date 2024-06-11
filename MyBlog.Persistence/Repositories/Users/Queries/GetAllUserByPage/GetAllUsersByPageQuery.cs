using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Repositories.Users.Queries.GetAllUserByPage;
public class GetAllUsersByPageQuery : IQueryHandler<GetAllUsersByPageRequest, ICollection<AppUserDto>>
{
    private readonly AppReadDbContext _context;

    public GetAllUsersByPageQuery(AppReadDbContext context)
    {
        _context = context;
    }


    public async Task<Result<ICollection<AppUserDto>, Error>> Handle(GetAllUsersByPageRequest request, CancellationToken ct)
    {
        var users = _context.Users;

        var countUsers = users.Count();

        var usersResult = await users
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        return usersResult;
    }
}
