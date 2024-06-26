﻿using MyBlog.Api.Models.Users;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Api.Mappings;

public static class Users
{
    public static ShortUserViewModel ToShortUserViewModel(this AppUserDto dto)
    {
        var articles = dto.Articles
            .Select(a => a.ToArticleListViewModel()).ToList();
        return new ShortUserViewModel(
            dto.Id,
            dto.UserName,
            $"{dto.LastName} {dto.FirstName} {dto.SecondName}".Trim(),
            dto.BirthDate.Date,
            dto.RegistrationDate.Date
            );
    }
}
