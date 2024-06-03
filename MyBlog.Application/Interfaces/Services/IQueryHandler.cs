using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services;

public interface IQueryHandler<TRequest, TResponse> 
{
    Task<Result<ICollection<TResponse>, Error>> Handle(TRequest request, CancellationToken ct);
}

