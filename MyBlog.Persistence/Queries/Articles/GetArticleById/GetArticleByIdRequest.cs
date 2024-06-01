using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.Queries.Articles.GetArticleById
{
    public record GetArticleByIdRequest : IRequest<ArticleDto>
    {
        public Guid Id { get; set; }
    }
}
