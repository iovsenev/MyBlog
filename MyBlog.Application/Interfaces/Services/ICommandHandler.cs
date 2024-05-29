using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services
{
    public interface ICommandHandler <TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<Result<TResponse,Error>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
