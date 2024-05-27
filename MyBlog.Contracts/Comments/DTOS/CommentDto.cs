namespace MyBlog.Contracts.Comments.DTOS;

public record CommentDto(
    Guid Id,
    string Text,
    int Likes,
    int Dislikes,
    DateTimeOffset AddedDate,
    Guid Author,
    Guid Article);