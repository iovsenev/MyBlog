using CSharpFunctionalExtensions;
using MyBlog.Contracts.Articles.Requests;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.DataAccess
{
    public interface IRepository<TEnity>
    {
        Task<Result> Create(TEnity article, CancellationToken ct = default);
        Task<Result> Delete(Guid id, CancellationToken ct = default);
        Task<Result<IReadOnlyList<TEnity>, Error>> GetAll(int pageIndex, int sizePage, CancellationToken ct = default);
        Task<Result<TEnity, Error>> GetById(Guid id, CancellationToken ct = default);
    }
}