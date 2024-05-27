using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Contracts.Articles.Requests;
using MyBlog.Contracts.Articles.Response;
using MyBlog.Domain.Common;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Queries;
public class GetArticleQuery
{
    private readonly AppReadDbContext _context;

    public GetArticleQuery(AppReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result< ResponseArticle, Error>> Handle(GetAllArticlesByPageRequest request, CancellationToken ct)
    {
        var query = _context.Articles
            .Where(a => string.IsNullOrEmpty(request.autor) 
                    || a.Author.LastName.Contains(request.autor))
            .Where(a => string.IsNullOrEmpty(request.constains) 
                    || a.Text.Contains(request.constains))
            .OrderBy(a => a.Likes);

        var totalCount = await query.CountAsync(ct);

        var articles = await query
            .Skip(request.PageIndex * request.SizePage)
            .Take(request.SizePage)
            .ToListAsync(ct);

        return new ResponseArticle(articles, totalCount);

    }
}
