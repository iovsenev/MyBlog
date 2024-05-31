using MyBlog.Application.Users.DTOS;

namespace MyBlog.Application.Users.Queries.GetAllUsers;

public record GetAllUsersResponse(ICollection<AppUserDto> users);