namespace MyBlog.Contracts.Articles.DTOS;

public record ArticleDto(
    Guid Id,
    string Title,
    string Description,
    string Text,
    DateTimeOffset AddedDate,
    int Likes,
    int Dislikes,
    string Author,
    List<ImageDto> Images
    );
