using MyBlog.Contracts.Articles.DTOS;
using MyBlog.Contracts.Comments.DTOS;

namespace MyBlog.Contracts.AppUsers.DTOS;

public record AppUserDto(
    Guid Id,
    string UserName,
    string PasswordHash,
    string Email,
    string FirstName,
    string LastName,
    string SecondName,
    DateTimeOffset BirthDate,
    string Phone,
    DateTimeOffset RegistrationDate,
    IEnumerable<ArticleDto> Articles,
    IEnumerable<CommentDto> Comments);