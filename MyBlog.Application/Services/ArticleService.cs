using CSharpFunctionalExtensions;
using MyBlog.Application.Articles.Queries.GetAllArticles;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Services
{
    public class ArticleService 
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Delete(Guid id, CancellationToken ct = default)
        {
            if (id.Equals(Guid.Empty))
                return Result.Failure(Errors.General.InValid(id).Serialize());

            return await _repository.Delete(id, ct);
        }

        public async Task<Result<Article, Error>> GetById(Guid id, CancellationToken ct = default)
        {
            if (id.Equals(Guid.Empty))
                return Errors.General.InValid(id);

            var result = await _repository.GetById(id, ct);
            if (result.IsFailure)
                return result.Error;

            return result.Value;
        }

        public async Task<Result<IEnumerable <Article> , Error>> GetAll(
            GetAllArticlesRequest request,
            CancellationToken ct = default)
        {
            var result = await _repository.GetAll(request.PageIndex, request.SizePage, ct);

            if (result.IsFailure)
                return result.Error;

            return result.Value.ToList();
        }
    }
}
