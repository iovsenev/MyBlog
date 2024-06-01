using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services;

public interface IQueryHandler<TRequest, TResponse> : IQueryHandler<TRequest>
{
    Task<Result<ICollection<TResponse>, Error>> Handle(TRequest? request, CancellationToken ct);
}

public interface IQueryHandler<TResponse>
{
    Task<Result<ICollection<TResponse>, Error>> Handle(CancellationToken ct);
}

