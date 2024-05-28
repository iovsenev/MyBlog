using CSharpFunctionalExtensions;
using MyBlog.Application.Articles.Queries.GetArticles;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services
{
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<Result<TResponse, Error>> Handle(TRequest request, CancellationToken ct);
    }
}
