using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Application.Interfaces.DataAccess;

public interface IUserRepository : IRepository<AppUser>
{
}