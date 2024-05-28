using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Articles.Queries.GetArticles;

public class GetAllArticlesRequest : IRequest<GetAllArticleResponse>
{
    public GetAllArticlesRequest(
    string? autor,
    string? constains,
    int pageIndex = 1,
    int sizePage = 10)
    {
        Autor = autor;
        Constains = constains;
        PageIndex = pageIndex;
        SizePage = sizePage;
    }

    public string? Autor { get; set; }
    public string? Constains { get; set;}
    public int PageIndex { get; set; } = 1;
    public int SizePage { get; set; } = 10;
}