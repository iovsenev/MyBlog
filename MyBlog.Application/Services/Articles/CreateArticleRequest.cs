namespace MyBlog.Application.Services.Articles;
public record CreateArticleRequest(
    Guid AuthorId,
    string Tittle,
    string Description,
    string Text);
