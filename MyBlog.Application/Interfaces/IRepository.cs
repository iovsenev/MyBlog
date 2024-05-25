using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Persistence.Repositories
{
    public interface IRepository<TEnity>
    {
        Task<Result> Create(TEnity article, CancellationToken ct = default);
        Task<Result> Delete(Guid id, CancellationToken ct = default);
        Task<Result<IReadOnlyList<TEnity>, Error>> GetAll(CancellationToken ct = default);
        Task<Result<TEnity, Error>> GetById(Guid id, CancellationToken ct = default);
    }
}