using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Articles.Queries.GetAllArticles;
public class GetAllArticleQueryHandler : IQueryHandler<GetAllArticlesRequest, GetAllArticleResponse>
{
    private readonly IReadDbContext _context;

    public GetAllArticleQueryHandler(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllArticleResponse, Error>> Handle(GetAllArticlesRequest request, CancellationToken ct)
    {
        var query = _context.Articles
            .Include(U => U.Author)
            .Where(a => string.IsNullOrEmpty(request.Autor)
                    || a.Author.LastName.Contains(request.Autor))
            .Where(a => string.IsNullOrEmpty(request.Contains)
                    || a.Text.Contains(request.Contains))
            .OrderBy(a => a.Likes);

        var totalCount = await query.CountAsync(ct);

        var articles = await query
            .Skip((request.PageIndex - 1) * request.SizePage)
            .Take(request.SizePage)
            .ToListAsync(ct);

        return new GetAllArticleResponse(articles, totalCount);
    }
}
