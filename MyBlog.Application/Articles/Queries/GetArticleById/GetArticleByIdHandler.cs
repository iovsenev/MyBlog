using CSharpFunctionalExtensions;
using MyBlog.Application.Articles.Dtos;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Articles.Queries.GetArticleById
{
    public class GetArticleByIdHandler : IQueryHandler<GetArticleByIdRequest, GetArticleDto>
    {
        private readonly IReadDbContext _context;
        public GetArticleByIdHandler(IReadDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetArticleDto, Error>> Handle(GetArticleByIdRequest request, CancellationToken ct)
        {
            var resultArticle = await _context.Articles.FindAsync(request.Id, ct);

            return resultArticle is null ? Errors.General.NotFound(request.Id) : resultArticle;
        }
    }
}
