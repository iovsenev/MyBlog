using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Users.DTOS;

namespace MyBlog.Application.Users.Queries
{
    public class GetUserByIdRequest : IRequest<AppUserDto>
    {
        public Guid Id { get; set; }
    }
}
