using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Application.Interfaces.DataAccess;
public interface IRepository<TEntity>
{
    Task<Result<Guid, Error>> Create(TEntity user, CancellationToken ct);
    Task<Result<TEntity, Error>> GetById(Guid id, CancellationToken ct);
}