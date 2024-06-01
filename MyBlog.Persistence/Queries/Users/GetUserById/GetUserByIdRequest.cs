using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.Queries.Users.GetUserById;

public class GetUserByIdRequest : IRequest<AppUserDto>
{
    public Guid Id { get; set; }
}
