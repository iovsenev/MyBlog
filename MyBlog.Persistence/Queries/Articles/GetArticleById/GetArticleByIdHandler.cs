using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.Queries.Articles.GetArticleById
{
    public class GetArticleByIdHandler : IQueryHandler<GetArticleByIdRequest, ArticleDto>
    {
        private readonly IReadDbContext _context;
        public GetArticleByIdHandler(IReadDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ArticleDto, Error>> Handle(GetArticleByIdRequest request, CancellationToken ct)
        {
            var resultArticle = await _context.Articles.FindAsync(request.Id, ct);

            return resultArticle is null ? Errors.General.NotFound(request.Id) : resultArticle;
        }
    }
}
