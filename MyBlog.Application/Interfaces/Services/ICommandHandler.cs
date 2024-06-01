using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services;

public interface ICommandHandler <TRequest, TResponse>
{
    Task<Result<TResponse,Error>> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandHandler<TRequest>
{
    Task<Result<Guid, Error>> Handle(TRequest request, CancellationToken cancellationToken);
}
