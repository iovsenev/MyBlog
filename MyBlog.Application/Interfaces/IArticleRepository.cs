using MyBlog.Domain.Entities;
using MyBlog.Persistence.Repositories;

namespace MyBlog.Application.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
