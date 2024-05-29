using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Users.DTOS;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Users.Queries
{
    public class GetUserByIdHandler : ICommandHandler<GetUserByIdRequest, AppUserDto>
    {
        private readonly IReadDbContext _context;

        public GetUserByIdHandler(IReadDbContext context)
        {
            _context = context;
        }

        public async Task<Result<AppUserDto, Error>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var userResult = await _context.Users.FindAsync(request.Id, cancellationToken);

            return userResult is null ? Errors.General.NotFound(request.Id) : userResult;
        }
    }
}
