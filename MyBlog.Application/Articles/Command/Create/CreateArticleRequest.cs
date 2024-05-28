using CSharpFunctionalExtensions;
using MediatR;

namespace MyBlog.Application.Articles.Command.Create
{
    public record CreateArticleRequest(
        Guid AuthorId,
        string Title,
        string Description,
        string Text) : IRequest<Result>;
}