using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Users.Queries.GetAllUsers;
public class GetAllUsersHandler : IQueryHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly IReadDbContext _context;

    public GetAllUsersHandler(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllUsersResponse, Error>> Handle(GetAllUsersRequest request, CancellationToken ct)
    {
        var users = await _context.Users
            .ToListAsync();

        return new GetAllUsersResponse(users);
    }
}
