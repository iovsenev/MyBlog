using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Articles.Queries.GetAllArticles;

public class GetAllArticlesRequest : IRequest<GetAllArticleResponse>
{
    //public GetAllArticlesRequest(
    //string? autor,
    //string? contains,
    //int pageIndex = 1,
    //int sizePage = 10)
    //{
    //    Autor = autor;
    //    Contains = contains;
    //    PageIndex = pageIndex;
    //    SizePage = sizePage;
    //}

    public string? Autor { get; set; }
    public string? Contains { get; set; }
    public int PageIndex { get; set; } = 1;
    public int SizePage { get; set; } = 10;
}