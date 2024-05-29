using MyBlog.Application.Articles.Dtos;
using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Application.Articles.Queries.GetArticleById
{
    public record GetArticleByIdRequest : IRequest<GetArticleDto>
    {
        public Guid Id { get; set; }
    }
}
