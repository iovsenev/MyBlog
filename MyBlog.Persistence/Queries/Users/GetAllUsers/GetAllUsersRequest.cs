using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.Queries.Users.GetAllUsers;
public class GetAllUsersRequest() : IRequest<List<AppUserDto>>;
