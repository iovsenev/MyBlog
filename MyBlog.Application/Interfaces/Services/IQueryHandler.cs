using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services
{
    public interface IQueryHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<Result<TResponse, Error>> Handle(TRequest request, CancellationToken ct);
    }
}
