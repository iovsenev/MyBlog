using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces;
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

        public async Task<Result> Create(CreateArticleRequest request, CancellationToken ct = default)
        {
            var resultArticle = Article.Create(request.Title, request.Description, request.Text);

            if (resultArticle.IsFailure)
                return Result.Failure(resultArticle.Error.Serialize());

            var result = await _repository.Create(resultArticle.Value, ct);

            return result;
        }

        public async Task<Result> Delete(Guid id, CancellationToken ct = default)
        {
            if (id.Equals(Guid.Empty))
                return Result.Failure(Errors.General.InValid(id).Serialize());

            return await _repository.Delete(id, ct);
        }

        public async Task<Result<ResponseArticle, Error>> GetById(Guid id, CancellationToken ct = default)
        {
            if (id.Equals(Guid.Empty))
                return Errors.General.InValid(id);

            var result = await _repository.GetById(id, ct);
            if (result.IsFailure)
                return result.Error;

        }
    }
}
