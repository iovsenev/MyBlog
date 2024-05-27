using MyBlog.Contracts.AppUsers.DTOS;
using MyBlog.Contracts.Comments.DTOS;
using MyBlog.Contracts.Images.DTOS;

namespace MyBlog.Contracts.Articles.DTOS;

public record ArticleDto(
    Guid Id,
    string Title,
    string Description,
    string Text,
    DateTimeOffset AddedDate,
    int Likes,
    int Dislikes,
    AppUserDto Author,
    IEnumerable<ImageDto> Images,
    IEnumerable<CommentDto> Comments
    );
