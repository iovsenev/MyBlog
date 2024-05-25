namespace MyBlog.Application.Services
{
    public record CreateArticleRequest(
        string Title,
        string Description,
        string Text);
}