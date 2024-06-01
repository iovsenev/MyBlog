using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Persistence.Repositories.Articles.Create
{
    public record CreateArticleRequest(
        Guid AuthorId,
        string Title,
        string Description,
        string Text) : IRequest<Guid>;
}