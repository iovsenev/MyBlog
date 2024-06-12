using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Repositories.Articles.Queries.GetAllArticle;
public class GetAllArticleQuery : IQueryHandler<GetArticleRequest, ICollection<ArticleDto>>
{
    private AppReadDbContext _appReadDbContext;

    public GetAllArticleQuery(AppReadDbContext appReadDbContext)
    {
        _appReadDbContext = appReadDbContext;
    }

    public async  Task<Result<ICollection<ArticleDto>, Error>> Handle(GetArticleRequest request, CancellationToken ct)
    {
        var articles = await _appReadDbContext.ArticleDTOs.ToListAsync(ct);

        if (articles is null)
            return Errors.General.InValid();

        return articles;
    }
}
