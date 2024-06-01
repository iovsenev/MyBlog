using MyBlog.Api.Models.Users;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Api.Mappings;

public static class Users
{
    public static UserViewModelForList ToUserListViewModel (this AppUserDto dto)
    {
        return new UserViewModelForList(
            dto.Id,
            dto.UserName,
            $"{dto.LastName} {dto.FirstName} {dto.SecondName}".Trim(),
            dto.BirthDate.Date,
            dto.RegistrationDate.Date);
    }

    public static UserViewModelSingle ToUserSingleViewModel(this AppUserDto dto)
    {
        var articles = dto.Articles
            .Select(a => a.ToArticleListViewModel()).ToList();
        return new UserViewModelSingle(
            dto.Id,
            dto.UserName,
            $"{dto.LastName} {dto.FirstName} {dto.SecondName}".Trim(),
            dto.BirthDate.Date,
            dto.RegistrationDate.Date,
            articles
            );
    }
}
