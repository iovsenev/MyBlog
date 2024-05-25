namespace MyBlog.Contracts.Articles.Requests
{
    public record CreateArticleRequest(
        string Title,
        string Description,
        string Text);
}