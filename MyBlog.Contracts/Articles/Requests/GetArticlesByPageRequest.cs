namespace MyBlog.Contracts.Articles.Requests
{
    public record GetArticlesByPageRequest(int PageIndex = 1, int SizePage = 10);
}
