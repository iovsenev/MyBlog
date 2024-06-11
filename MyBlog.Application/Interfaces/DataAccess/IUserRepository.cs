using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Application.Interfaces.DataAccess;

public interface IUserRepository : IRepository<AppUser>
{
    Task<Result<Guid, Error>> Save(AppUser user, CancellationToken ct);
}