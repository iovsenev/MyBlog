using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Articles.Queries.GetArticles;
public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticlesRequest, GetAllArticleResponse>
{
    private readonly IReadDbContext _context;

    public GetAllArticleQueryHandler(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllArticleResponse, Error>> Handle(GetAllArticlesRequest request, CancellationToken ct)
    {
        var query = _context.Articles
            .Where(a => string.IsNullOrEmpty(request.Autor)
                    || a.Author.LastName.Contains(request.Autor))
            .Where(a => string.IsNullOrEmpty(request.Constains)
                    || a.Text.Contains(request.Constains))
            .OrderBy(a => a.Likes);

        var totalCount = await query.CountAsync(ct);

        var articles = await query
            .Skip(request.PageIndex * request.SizePage)
            .Take(request.SizePage)
            .ToListAsync(ct);

        return new GetAllArticleResponse(articles, totalCount);
    }
}
