using MyBlog.Api.Models.Users;
using MyBlog.Application.Users.DTOS;

namespace MyBlog.Api.Mappings;

public static class Users
{
    public static UserViewModel ToUserViewModel (this AppUserDto dto)
    {
        return new UserViewModel(
            dto.Id,
            dto.UserName,
            dto.FirstName,
            dto.SecondName,
            dto.LastName,
            dto.BirthDate.Date,
            dto.RegistrationDate.Date);
    }
}
