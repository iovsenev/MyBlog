namespace MyBlog.Contracts.Articles.Requests;

public record GetAllArticlesByPageRequest(
    string? autor,
    string? constains,
    int PageIndex = 1, 
    int SizePage = 10);
